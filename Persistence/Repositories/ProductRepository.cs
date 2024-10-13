using AutoMapper;
using Dapper;
using Fashion.Domain;
using Fashion.Domain.Abstractions.Repositories.ReadSide;
using Fashion.Domain.Abstractions.Repositories.WriteSide;
using Fashion.Domain.DTOs.Entities.Product;
using Fashion.Domain.DTOs.Identity;
using Fashion.Domain.Entities;
using Fashion.Domain.Exceptions;
using Fashion.Domain.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class ProductRepository : RepositoryBase<Product, Guid>, IProductReadSideRepository, IProductWriteSideRepository
    {
        public ProductRepository(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Guid> CreateAsync(CreateProductDto productDto, PayloadToken payloadToken)
        {
            Product newProduct = _mapper.Map<Product>(productDto);
            Guid newId = await CreateAsync(newProduct, payloadToken);
            return newId;
        }
        public async Task<bool> UpdateAsync(ProductGetByIdDto obj, PayloadToken payloadToken)
        {
            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    Product objMap = _mapper.Map<Product>(obj);
                    FashionStoresContext? dbContext = _unitOfWork.GetDbContext() as FashionStoresContext;
                    Product? isExist = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == obj.Id);
                    if (isExist == null)
                    {
                        throw new Exception();
                    }
                    dbContext.Entry(isExist).CurrentValues.SetValues(objMap);

                    using (var connection = new SqlConnection(dbContext.Database.GetConnectionString()))
                    {
                        await connection.OpenAsync();
                        var transaction2 = await connection.BeginTransactionAsync();
                        try
                        {
                            //ProductImage
                            foreach (var image in obj.productImages)
                            {
                                if (image.Id == null)
                                {
                                    image.Id = Guid.NewGuid();
                                    image.ProductId = obj.Id;
                                    dbContext.ProductImages.Add(_mapper.Map<ProductImage>(image));
                                }
                                else if (image.IsDeleted ?? false)
                                {
                                    UploadHelper uploadHelper = new UploadHelper();
                                    uploadHelper.DeleteFile(image.ImageUrl);
                                    string queryDelete = @$"
                                    Delete ProductImage where Id = @Id";
                                    var parameters = new { Id = image.Id };
                                    connection.Execute(queryDelete, parameters, transaction2);
                                }
                            }
                            //ProductVariant
                            foreach (var variant in obj.ProductVariants)
                            {
                                if (variant.Id == null)
                                {
                                    variant.Id = Guid.NewGuid();
                                    variant.ProductId = objMap.Id;
                                    dbContext.ProductVariant.Add(_mapper.Map<ProductVariant>(variant));
                                }
                                else if (variant.IsEdited ?? false) // Default false
                                {
                                    string queryUpdate = $@"
                                    Update ProductVariant set
                                        Size = @Size,
                                        Color = @Color,                                   
                                        Inventory = @Inventory,                                   
                                        ImageUrl = @ImageUrl,
                                        Price = @Price,
                                        IsDeleted = @IsDeleted
                                    Where Id = @Id
";
                                    var parameters = new
                                    {
                                        Id = variant.Id,
                                        Size = variant.Size,
                                        Color = variant.Color,
                                        Inventory = variant.Inventory,
                                        ImageUrl = variant.ImageUrl,
                                        Price = variant.Price,
                                        IsDeleted = (variant.IsDeleted ?? false) ? 1 : 0
                                    };
                                    connection.Execute(queryUpdate, parameters, transaction2);
                                }
                            }

                            await transaction2.CommitAsync();
                        }
                        catch (Exception)
                        {
                            await transaction2.RollbackAsync();
                            throw;
                        }
                        finally { connection.Close(); }

                    }

                    await _unitOfWork.EndTransactionAsync();
                    return true;
                }
                catch (Exception)
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    throw;
                }
            }

        }
        public async Task<IEnumerable<ProductDto>> FindAll(OptionFilter option)
        {
            var query = FindAll()
                .Where(x => (x.Name == null || x.Name.Contains(option.Name ?? ""))
                && (option.CategoryId == null || option.CategoryId == x.CategoryId)
                );
            ProductDto.TotalRecordsCount = await query.CountAsync();
            List<ProductDto> products = await query
                .Skip((option.PageIndex - 1) * option.PageSize).Take(option.PageSize)
                .Select(x => new ProductDto()
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName,
                    Name = x.Name,
                    MainImageUrl = x.MainImageUrl,
                    TotalInventory = x.TotalInventory,
                    Description = x.Description,
                })
                .ToListAsync();
            if (!products.Any())
            {
                throw new NotFoundDataException();
            }
            return products;
        }

        public async Task<ProductGetByIdDto> FindById(Guid id)
        {
            var res = await FindAll()
                .Include(x => x.ProductVariants)
                .Include(x => x.ProductImages)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (res == null)
            {
                throw new NotFoundDataException();
            }
            return _mapper.Map<ProductGetByIdDto>(res); ;
        }

    }
}
