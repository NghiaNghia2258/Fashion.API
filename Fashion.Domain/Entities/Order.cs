using Fashion.Domain.Abstractions;
using Fashion.Domain.Abstractions.Entities;

namespace Domain.Entities;

public partial class Order : EntityBase<Guid>, ICreateTracking, IUpdateTracking, ISoftDelete
{
    public string? Note { get; set; }

    public string? CustomerNote { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public double? Tax { get; set; }

    public double? DiscountPercent { get; set; }

    public double? DiscountValue { get; set; }

    public Guid? CustomerId { get; set; }

    public Guid? VoucherId { get; set; }

    public Guid? RecipientsInformationId { get; set; }

    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? CreatedName { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public string? UpdatedName { get; set; }
    public bool? IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    public string? DeletedName { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual RecipientsInformation? RecipientsInformation { get; set; }

    public virtual Voucher? Voucher { get; set; }
}
