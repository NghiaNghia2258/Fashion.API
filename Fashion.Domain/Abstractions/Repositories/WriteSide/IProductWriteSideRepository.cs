using Fashion.Domain.DTOs.Entities.Product;
using Fashion.Domain.DTOs.Identity;

namespace Fashion.Domain.Abstractions.Repositories.WriteSide
{
    public interface IProductWriteSideRepository
    {
        Task<Guid> CreateAsync(CreateProductDto productDto, PayloadToken payloadToken);
        Task<bool> UpdateAsync(ProductGetByIdDto obj, PayloadToken payloadToken);
    }
}
