using Fashion.Domain.DTOs.Entities.OrderItem;

namespace Fashion.Domain.DTOs.Entities.Order;

public class OrderGetByIdDto : OrderDto
{
    public IEnumerable<OrderItemDto> OrderItems { get; set; }
}
