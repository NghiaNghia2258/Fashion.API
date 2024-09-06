using Fashion.Domain.Entities;
using Fashion.Domain.DTOs.Entities.Product;
using Fashion.Domain.Parameters;

namespace Fashion.Domain.Abstractions.Repositories.ReadSide
{
    public interface IProductReadSideRepository
    {
        Task<IEnumerable<ProductDto>> FindAll(PagingRequestParameters paging);
        Task<Product> FindById(Guid id);
    }
}
