using Fashion.Domain.Abstractions;
using Fashion.Domain.Abstractions.Entities;

namespace Fashion.Domain.Entities;

public partial class Product: EntityBase<Guid>, IAuditableEntity
{
    public string Name { get; set; } = null!;

    public string? NameEn { get; set; }

    public string? Description { get; set; }

    public string? MainImageUrl { get; set; }
    public double? TotalInventory { get; set; } = 0;
    public Guid? CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public DateTime? CreatedAt { get ; set ; }
    public string? CreatedBy { get ; set ; }
    public string? CreatedName { get ; set ; }
    public DateTime? UpdatedAt { get ; set ; }
    public string? UpdatedBy { get ; set ; }
    public string? UpdatedName { get ; set ; }
    public bool IsDeleted { get ; set ; } = false;
    public DateTime? DeletedAt { get ; set ; }
    public string? DeletedBy { get ; set ; }
    public string? DeletedName { get ; set ; }

    public virtual ProductCategory? Category { get; set; }
    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<ProductRate> ProductRates { get; set; } = new List<ProductRate>();
    public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
}
