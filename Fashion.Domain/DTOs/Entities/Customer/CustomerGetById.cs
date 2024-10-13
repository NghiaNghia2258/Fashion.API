namespace Fashion.Domain.DTOs.Entities.Customer;

public class CustomerGetById
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Code { get; set; }

    public string? Phone { get; set; }

    public string Gender { get; set; } = null!;
    public int? Point { get; set; }
    public double? Debt { get; set; }

    public Guid? UserLoginId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? CreatedName { get; set; }
    public bool? IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    public string? DeletedName { get; set; }
    public int Version { get; set; }
}
