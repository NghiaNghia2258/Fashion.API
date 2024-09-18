using AutoMapper;
using Fashion.Domain;
using Fashion.Domain.Abstractions.Repositories.ReadSide;
using Fashion.Domain.Entities;

namespace Persistence.Repositories
{
    public class OrderRepository : RepositoryBase<Order, Guid>, IOrderReadSideRepository
    {
        public OrderRepository(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

    }
}
