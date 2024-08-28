using Fashion.Domain.Abstractions;
using Fashion.Domain.Abstractions.Entities;

namespace Domain.Entities;

public partial class Product: EntityBase<Guid>, ICreateTracking, IUpdateTracking, ISoftDelete
{
    public string Name { get; set; } = null!;

    public string? NameEn { get; set; }

    public string Size { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string? Description { get; set; }

    public double Price { get; set; }

    public int? Inventory { get; set; }

    public string? MainImageUrl { get; set; }

    public Guid? CategoryId { get; set; }
    public DateTime? CreatedAt { get ; set ; }
    public string? CreatedBy { get ; set ; }
    public string? CreatedName { get ; set ; }
    public DateTime? UpdatedAt { get ; set ; }
    public string? UpdatedBy { get ; set ; }
    public string? UpdatedName { get ; set ; }
    public bool? IsDeleted { get ; set ; }
    public DateTime? DeletedAt { get ; set ; }
    public string? DeletedBy { get ; set ; }
    public string? DeletedName { get ; set ; }

    public virtual ProductCategory? Category { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<ProductRate> ProductRates { get; set; } = new List<ProductRate>();
    
}
