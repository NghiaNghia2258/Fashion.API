using AutoMapper;
using Fashion.Domain;
using Fashion.Domain.Abstractions.Repositories.ReadSide;
using Fashion.Domain.Abstractions.Repositories.WriteSide;
using Fashion.Domain.DTOs.Entities.Order;
using Fashion.Domain.DTOs.Entities.OrderItem;
using Fashion.Domain.DTOs.Identity;
using Fashion.Domain.Entities;
using Fashion.Domain.Enum;
using Fashion.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class OrderRepository : RepositoryBase<Order, Guid>, IOrderReadSideRepository, IOrderWriteSideRepository
    {
        public OrderRepository(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        public async Task<IEnumerable<OrderDto>> Filter(Fashion.Domain.DTOs.Entities.Order.OptionFilter option)
        {
            var res = await FindAll()
                .Where(x => (option.CreatedAt == null || x.CreatedAt == option.CreatedAt)
                && (option.CreatedBy == null || option.CreatedBy == x.CreatedBy)
                )
                .Select(x => new OrderDto()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    CreatedAt = x.CreatedAt,
                    CreatedName = x.CreatedName,
                    CustomerName = x.CustomerName,
                    DiscountPercent = x.DiscountPercent,
                    DiscountValue = x.DiscountValue,
                    Status = x.PaymentStatus,
                    Tax = x.Tax,
                    TotalPrice = x.TotalPrice,
                })
                    .Skip((option.PageIndex - 1)  * option.PageSize)
                    .Take(option.PageSize)
                    .ToListAsync();
            if(res == null)
            {
                throw new NotFoundDataException();
            }
            return res;
        }
        public async Task<OrderGetByIdDto> FindById(Guid id)
        {
            OrderGetByIdDto? res = await FindAll().Include(x => x.OrderItems)
                .Select(x => new OrderGetByIdDto()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    CreatedAt = x.CreatedAt,
                    CreatedName = x.CreatedName,
                    CustomerName = x.CustomerName,
                    DiscountPercent = x.DiscountPercent,
                    DiscountValue = x.DiscountValue,
                    Status = x.PaymentStatus,
                    Tax = x.Tax,
                    TotalPrice = x.TotalPrice,
                    OrderItems = _mapper.Map<IEnumerable<OrderItemDto>>(x.OrderItems)
                }).FirstOrDefaultAsync();
            if(res == null)
            {
                throw new NotFoundDataException($"Order with id ({id}) does not exist");
            }
            return res;
        }

        public async Task<bool> Update(OrderGetByIdDto orderDto)
        {
            Order objMap = _mapper.Map<Order>(orderDto);
            FashionStoresContext? dbContext = _unitOfWork.GetDbContext() as FashionStoresContext;

            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    if (orderDto.Id == null)
                    {
                        objMap.Id = Guid.NewGuid();
                        dbContext.Orders.Add(objMap);
                    }
                    else
                    {
                        Order? isExist = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == orderDto.Id);
                        if (isExist == null)
                        {
                            throw new NotFoundDataException($"Order with id ({orderDto.Id}) does not exist");
                        }
                        dbContext.Entry(isExist).CurrentValues.SetValues(objMap);
                        foreach (OrderItemDto orderItem in orderDto.OrderItems)
                        {
                            OrderItem? obj = await dbContext.OrderItems.FindAsync(orderItem.Id);
                            if (obj == null)
                            {
                                orderItem.Id = Guid.NewGuid();
                                orderItem.OrderId = objMap.Id;
                                dbContext.OrderItems.Add(_mapper.Map<OrderItem>(orderItem));
                            }
                            else if (orderItem.IsDeleted ?? false)
                            {
                                dbContext.OrderItems.Remove(obj);
                            }
                            else
                            {
                                dbContext.Entry(obj).CurrentValues.SetValues(orderItem);
                            }
                        }
                    }

                    await _unitOfWork.EndTransactionAsync();
                    return true;
                }
                catch (Exception)
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    throw;
                }
            }
        }

        public async Task<bool> Payment(Guid id,PayloadToken payloadToken)
        {
            var res = await GetByIdAsync(id);
            res.PaymentStatus = (int?)StatusOrder.Payment;
            await UpdateAsync(res,payloadToken);
            return true;
        }
    }
}
