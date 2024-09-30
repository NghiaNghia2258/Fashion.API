namespace Fashion.Domain.Enum
{
    public enum StatusOrder : int
    {
        Unknown = 0,
        Pending = 1,
        Confirmed = 2,
        Shipped = 3,
        Delivered = 4,
        Cancelled = 5,
        Returned = 6,
        Refunded = 7,
        Payment = 8
    }
}
