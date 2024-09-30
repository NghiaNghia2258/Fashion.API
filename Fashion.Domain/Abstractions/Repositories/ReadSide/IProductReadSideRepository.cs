using Fashion.Domain.DTOs.Entities.Product;

namespace Fashion.Domain.Abstractions.Repositories.ReadSide
{
    public interface IProductReadSideRepository
    {
        Task<IEnumerable<ProductDto>> FindAll(OptionFilter option);
        Task<ProductGetByIdDto> FindById(Guid id);
    }
}
