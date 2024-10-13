namespace Fashion.Domain.DTOs.Entities.Product;

public class ProductDto
{
    public static int TotalRecordsCount { get; set; }
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
    public double? TotalInventory { get; set; } = 0;
    public string? Description { get; set; }

    public string? MainImageUrl { get; set; }
    public Guid? CategoryId { get; set; }
    public string? CategoryName { get; set; }
}
