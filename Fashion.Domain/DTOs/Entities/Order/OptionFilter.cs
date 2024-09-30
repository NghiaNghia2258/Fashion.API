using Fashion.Domain.Parameters;

namespace Fashion.Domain.DTOs.Entities.Order
{
    public class OptionFilter: PagingRequestParameters
    {
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
    }
}
