using Fashion.Domain.Parameters;

namespace Fashion.Domain.DTOs.Entities.Product
{
    public class OptionFilter: PagingRequestParameters
    {
        public string? Name { get; set; }
        public double? PriceMin { get; set; }
        public double? PriceMax { get; set;}
        public Guid? CategoryId { get; set; }

    }
}
