using Fashion.Domain.Abstractions;
using Fashion.Domain.Abstractions.Entities;

namespace Fashion.Domain.Entities;

public partial class Voucher : EntityBase<Guid>, ICreateTracking
{
    public string VoucherCode { get; set; } = null!;
    public string? Title { get; set; }
    public string? Description { get; set; }

    public double? DiscountPercent { get; set; }

    public double? DiscountValue { get; set; }
    public double? MaxDiscountValue { get; set; }
    public double? MinOrderValue { get; set; }

    public int? UsedCount { get; set; }
    public int? UsageLimit { get; set; }


    public DateTime StartDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? CreatedName { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
