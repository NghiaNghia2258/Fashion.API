using Fashion.Domain.DTOs.Entities.Customer;

namespace Fashion.Domain.Abstractions.Repositories.ReadSide;

public interface ICustomerReadSideRepository
{
    Task<IEnumerable<CustomerDto>> Filter(OptionFilter option);
    Task<CustomerGetById> FindById(Guid id);
}
