namespace Fashion.Domain.Consts
{
    public static class TimeConst
    {
        public static DateTime ThreeMonthsAgo { get => DateTime.Now.AddMonths(-3); }
        public static DateTime Now { get => DateTime.Now; }
    }
}
