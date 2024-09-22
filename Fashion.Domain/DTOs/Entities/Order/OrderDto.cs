namespace Fashion.Domain.DTOs.Entities.Order;

public class OrderDto
{
    public Guid? Id { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public int? Status { get; set; } = 1!;
    public string? CustomerName { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedName { get; set; }
    public double? Tax { get; set; }
    public double? TotalPrice { get; set; }
    public double? DiscountPercent { get; set; }
    public double? DiscountValue { get; set; }

}
