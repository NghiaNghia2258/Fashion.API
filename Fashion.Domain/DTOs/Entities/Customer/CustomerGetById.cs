namespace Fashion.Domain.DTOs.Entities.Customer;

public class CustomerGetById
{
    public Guid Id { get; set; }
    public int? Point { get; set; }

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string Gender { get; set; } = null!;
}
