using AutoMapper;
using Fashion.Domain.Entities;
using Fashion.Domain;
using Fashion.Domain.Abstractions.Repositories.ReadSide;
using Fashion.Domain.Abstractions.Repositories.WriteSide;
using Fashion.Domain.DTOs.Entities.Product;
using Fashion.Domain.DTOs.Identity;
using Fashion.Domain.Parameters;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class ProductRepository : RepositoryBase<Product, Guid>, IProductReadSideRepository, IProductWriteSideRepository
    {
        public ProductRepository(FashionStoresContext dbContext, IUnitOfWork unitOfWork, IMapper mapper) : base(dbContext, unitOfWork, mapper)
        {
        }

        public async Task<Guid> CreateAsync(CreateProductDto productDto, PayloadToken payloadToken)
        {
            Product newProduct = _mapper.Map<Product>(productDto);
            Guid newId = await CreateAsync(newProduct,payloadToken);
            return newId;
        }

        public async Task<IEnumerable<ProductDto>> FindAll(PagingRequestParameters paging)
        {
            List<Product> products = await FindAll().Skip((paging.PageIndex - 1) * paging.PageSize).Take(paging.PageSize).ToListAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public Task<Product> FindById(Guid id)
        {
            return GetByIdAsync(id);
        }
    }
}
