using Fashion.Domain.Abstractions;
using Fashion.Domain.Abstractions.Entities;

namespace Fashion.Domain.Entities;

public partial class Customer : EntityBase<Guid>, ISoftDelete
{
    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string Gender { get; set; } = null!;
    public int? Point {  get; set; }

    public Guid? UserLoginId { get; set; }
    public bool? IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    public string? DeletedName { get; set; }


    public virtual ICollection<ProductRate> ProductRates { get; set; } = new List<ProductRate>();

    public virtual ICollection<RecipientsInformation> RecipientsInformations { get; set; } = new List<RecipientsInformation>();
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual UserLogin? UserLogin { get; set; }

}
