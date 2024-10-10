namespace Fashion.Domain.DTOs.Entities.Customer;

public class CustomerDto
{
    public static int TotalRecordsCountotal = 0;

    public Guid Id { get; set; }
    public string? Code { get; set; }
    
    public int? Point { get; set; }

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string Gender { get; set; } = null!;
    public double? Debt { get; set; }
    public double? QuarterlySpending { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? CreatedName { get; set; }
}
