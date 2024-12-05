using Fashion.Domain.Abstractions;
using Fashion.Domain.Abstractions.Entities;

namespace Fashion.Domain.Entities;

public partial class Order : EntityBase<Guid>, IAuditableEntity
{
    public string? Note { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public Guid? CustomerId { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerPhone { get; set; }
    public string? CustomerNote { get; set; }

    public int? PaymentStatus { get; set; } = 1!;

    public double? Tax { get; set; }

    public double? DiscountPercent { get; set; }

    public double? DiscountValue { get; set; }
    public double? TotalPrice { get; set; }
    public Guid? VoucherId { get; set; }
    public string? VoucherCode { get; set; }

    public Guid? RecipientsInformationId { get; set; }

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

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual RecipientsInformation? RecipientsInformation { get; set; }

    public virtual Voucher? Voucher { get; set; }
}
