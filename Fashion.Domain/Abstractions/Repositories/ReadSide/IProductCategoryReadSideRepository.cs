using Fashion.Domain.DTOs.Entities.ProductCategory;

namespace Fashion.Domain.Abstractions.Repositories.ReadSide
{
    public interface IProductCategoryReadSideRepository
    {
        Task<IEnumerable<ProductCategoryDto>> FindAll();
    }
}
