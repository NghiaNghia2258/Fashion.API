namespace Fashion.Domain.DTOs.Entities.Voucher;

public class VoucherDto
{
    public Guid? Id { get; set; }
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
}
