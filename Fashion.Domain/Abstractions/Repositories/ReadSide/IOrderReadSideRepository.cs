using Fashion.Domain.DTOs.Entities.Order;

namespace Fashion.Domain.Abstractions.Repositories.ReadSide;

public interface IOrderReadSideRepository
{
    Task<IEnumerable<OrderDto>> Filter(OptionFilter option);
    Task<OrderGetByIdDto> FindById(Guid id);
}
