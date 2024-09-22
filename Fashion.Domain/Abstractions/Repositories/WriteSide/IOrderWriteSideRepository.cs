using Fashion.Domain.DTOs.Entities.Order;

namespace Fashion.Domain.Abstractions.Repositories.WriteSide;

public interface IOrderWriteSideRepository
{
    Task<bool> Update(OrderGetByIdDto orderDto);
}
