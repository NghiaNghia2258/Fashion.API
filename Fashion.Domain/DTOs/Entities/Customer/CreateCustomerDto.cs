namespace Fashion.Domain.DTOs.Entities.Customer;

public class CreateCustomerDto
{
    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string Gender { get; set; } = null!;
}
