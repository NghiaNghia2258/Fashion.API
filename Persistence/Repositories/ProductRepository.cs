using AutoMapper;
using Dapper;
using Fashion.Domain;
using Fashion.Domain.Abstractions.Repositories.ReadSide;
using Fashion.Domain.Abstractions.Repositories.WriteSide;
using Fashion.Domain.DTOs.Entities.Product;
using Fashion.Domain.DTOs.Identity;
using Fashion.Domain.Entities;
using Fashion.Domain.Helpers;
using Fashion.Domain.Parameters;
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
            Guid newId = await CreateAsync(newProduct,payloadToken);
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

                   using(var connection = new SqlConnection(dbContext.Database.GetConnectionString()))
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
                        }finally { connection.Close(); }

                    }

                    await  _unitOfWork.EndTransactionAsync();
                    return true;
                }
                catch(Exception)
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    throw;
                }
            }
                
        }
//        List<Task> tasks = new List<Task>();
//                        foreach(var variant in obj.ProductVariants)
//                        {
//                            if(variant.Id == null)
//                            {
//                                variant.Id = Guid.NewGuid();
//                                variant.ProductId = objMap.Id;
//                                dbContext.ProductVariant.Add(_mapper.Map<ProductVariant>(variant));
//                            }
//                            else if(variant.IsEdited ?? false) // Mặc định là false
//                            {
//                                string queryUpdate = $@"
//                                    Update ProductVariant set
//                                        Size = '{variant.Size}',
//                                        Color = N'{variant.Color}',                                   
//                                        Inventory = {variant.Inventory},                                   
//                                        ImageUrl = '{variant.ImageUrl}',
//                                        Price = {variant.Price},
//                                        IsDeleted = {((variant.IsDeleted ?? false) ? 1 : 0)}
//                                    Where Id = '{variant.Id}'
//";
//    tasks.Add(connection.QueryAsync(queryUpdate, transaction));
//                            }
//                        }
//                        //ProductImage
//                        foreach (var image in obj.productImages)
//{
//    if (image.Id == null)
//    {
//        image.Id = Guid.NewGuid();
//        image.ProductId = obj.Id;
//        dbContext.ProductImages.Add(_mapper.Map<ProductImage>(image));
//    }
//    else if (image.IsDeleted ?? false)
//    {
//        UploadHelper uploadHelper = new UploadHelper();
//        uploadHelper.DeleteFile(image.ImageUrl);
//        string queryDelete = @$"
//                                    Delete ProductImage where Id = '{image.Id}'";
//        tasks.Add(connection.QueryAsync(queryDelete, transaction));
//    }
//}

//await Task.WhenAll(tasks);
public async Task<IEnumerable<ProductDto>> FindAll(PagingRequestParameters paging)
        {
            List<ProductDto> products = await FindAll().Skip((paging.PageIndex - 1) * paging.PageSize).Take(paging.PageSize)
                .Select( x => new ProductDto()
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    Name = x.Name,
                    NameEn = x.NameEn,
                    MainImageUrl = x.MainImageUrl,
                })
                .ToListAsync();
            return products;
        }

        public async Task<ProductGetByIdDto> FindById(Guid id)
        {
            var res = await FindAll()
                .Include(x => x.ProductVariants.Where(x => !(x.IsDeleted ?? false)))
                .Include(x => x.ProductImages)
                .FirstOrDefaultAsync(x => x.Id == id);
               return _mapper.Map<ProductGetByIdDto>(res); ;
        }

    }
}
