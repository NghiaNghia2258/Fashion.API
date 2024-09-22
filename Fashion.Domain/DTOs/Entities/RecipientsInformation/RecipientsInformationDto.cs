namespace Fashion.Domain.DTOs.Entities.RecipientsInformation;

public class RecipientsInformationDto
{
    public Guid? Id { get; set; }
    public Guid CustomerId { get; set; }

    public string RecipientsName { get; set; } = null!;

    public string RecipientsPhone { get; set; } = null!;

    public string RecipientsNote { get; set; } = null!;

    public string? Ward { get; set; }

    public string? District { get; set; }

    public string? City { get; set; }

    public string? Longiude { get; set; }

    public string? Latitude { get; set; }

    public string Detail { get; set; } = null!;

}
