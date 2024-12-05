using Fashion.Domain.Abstractions;
using Fashion.Domain.Abstractions.Entities;

namespace Fashion.Domain.Entities
{
    public partial class ProductVariant: EntityBase<Guid>, IAuditableEntity
    {
        public string Size { get; set; } = null!;

        public string Color { get; set; } = null!;

        public double Price { get; set; }
        public string ImageUrl { get; set; }

        public int? Inventory { get; set; }
        public Guid? ProductId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedName { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public string? UpdatedName { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }
        public string? DeletedName { get; set; }

        public virtual Product? Product { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}
