using Fashion.Domain.Abstractions;

namespace Domain.Entities;

public partial class OrderItem: EntityBase<Guid>
{

    public Guid? OrderId { get; set; }

    public Guid? ProductId { get; set; }

    public int Quantity { get; set; }

    public double UnitPrice { get; set; }

    public double? DiscountPercent { get; set; }

    public double? DiscountValue { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
