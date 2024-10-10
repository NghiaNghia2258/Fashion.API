using Fashion.Domain.Parameters;

namespace Fashion.Domain.DTOs.Entities.Customer;

public class OptionFilter: PagingRequestParameters
{
    public string? NameOrPhone { get; set; }
}
