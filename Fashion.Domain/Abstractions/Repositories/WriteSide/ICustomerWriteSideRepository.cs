using Fashion.Domain.DTOs.Entities.Customer;
using Fashion.Domain.DTOs.Identity;

namespace Fashion.Domain.Abstractions.Repositories.WriteSide;

public interface ICustomerWriteSideRepository
{
    Task<bool> Create(CreateCustomerDto obj, PayloadToken payload);
    Task<bool> Delete(Guid id, PayloadToken payload);
    Task<bool> Update(CustomerGetById obj, PayloadToken payload);
}
