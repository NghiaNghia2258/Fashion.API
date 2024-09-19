namespace Fashion.Domain.DTOs.Entities.ProductVariant
{
    public class ProductVariantDto
    {
        public Guid? Id { get; set; }
        public string Size { get; set; } = null!;

        public string Color { get; set; } = null!;

        public double Price { get; set; }
        public string ImageUrl { get; set; }

        public int? Inventory { get; set; }
        public Guid? ProductId { get; set; }
    }
}
