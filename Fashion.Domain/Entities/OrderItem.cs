using Fashion.Domain.Abstractions;
using Fashion.Domain.Entities;

namespace Fashion.Domain.Entities;

public partial class OrderItem: EntityBase<Guid>
{

    public Guid? OrderId { get; set; }

    public Guid? ProductVariantId { get; set; }
    public string? ImageUrl { get; set; }

    public int Quantity { get; set; }

    public double UnitPrice { get; set; }

    public double? DiscountPercent { get; set; }

    public double? DiscountValue { get; set; }

    public virtual Order? Order { get; set; }

    public virtual ProductVariant? ProductVariant { get; set; }
}
