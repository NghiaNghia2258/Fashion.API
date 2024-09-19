namespace Fashion.Domain.DTOs.Entities.ProductVariant;

public class CreateProductVariantDto
{
    public string Size { get; set; }

    public string Color { get; set; }

    public double Price { get; set; }
    public string ImageUrl { get; set; }

    public int? Inventory { get; set; }
}
