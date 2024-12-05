using Fashion.Domain.DTOs.Entities.Product;
using Fashion.Domain.DTOs.Entities.ProductVariant;

namespace Fashion.Domain.Abstractions.Repositories.ReadSide
{
    public interface IProductReadSideRepository
    {
        Task<IEnumerable<ProductDto>> FindAll(OptionFilter option);
        Task<IEnumerable<ProductVariantDto>> GetProductVariants(Guid id);
        Task<ProductGetByIdDto> FindById(Guid id);
    }
}
