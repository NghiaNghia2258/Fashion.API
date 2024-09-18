using AutoMapper;
using Fashion.Domain;
using Fashion.Domain.Abstractions.Repositories.ReadSide;
using Fashion.Domain.DTOs.Entities.ProductCategory;
using Fashion.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategory, Guid>, IProductCategoryReadSideRepository
    {
        public ProductCategoryRepository(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        public async Task<IEnumerable<ProductCategoryDto>> FindAll()
        {
            var res = await FindAll(trackChanges:false).Select(x => new ProductCategoryDto()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
            return res;
        }
    }
}
