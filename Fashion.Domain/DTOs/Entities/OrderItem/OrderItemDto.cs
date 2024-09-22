namespace Fashion.Domain.DTOs.Entities.OrderItem;

public class OrderItemDto
{
    public Guid? Id { get; set; }
    public Guid? OrderId { get; set; }
    public Guid? ProductVariantId { get; set; }
    public string? ProductVariantName { get; set;}
    public string? imageUrls { get; set;}
    public double? UnitPrice { get; set; }
    public double? DiscountPercent { get; set; }
    public double? DiscountValue { get; set; }
    public int? Quantity { get; set; }
}
