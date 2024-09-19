namespace Fashion.Domain.DTOs.Entities.ProductImage;

public class ProductImageDto
{
    public Guid? Id { get; set; }
    public string? ImageUrl { get; set; } = null!;
    public bool? IsDeleted { get; set; }
}
