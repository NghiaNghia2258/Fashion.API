using Fashion.Domain.Abstractions;
using Fashion.Domain.Abstractions.Entities;

namespace Domain.Entities;

public partial class Voucher : EntityBase<Guid>, ICreateTracking
{
    public string VoucherCode { get; set; } = null!;

    public double? DiscountPercent { get; set; }

    public double? DiscountValue { get; set; }

    public int? Redemptions { get; set; }

    public DateTime ExpirationDate { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? CreatedName { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
