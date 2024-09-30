using Fashion.Domain.DTOs.Entities.Order;
using Fashion.Domain.DTOs.Identity;

namespace Fashion.Domain.Abstractions.Repositories.WriteSide;

public interface IOrderWriteSideRepository
{
    Task<bool> Payment(Guid id, PayloadToken payloadToken);
    Task<bool> Update(OrderGetByIdDto orderDto);
}
