namespace Fashion.Domain.Abstractions.Entities
{
    public interface ICreateTracking
    {
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedName { get; set; }
    }
}
