namespace S14.Orders.Domain
{
    public class HistoryState
    {
        public int Id { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime Date { get; set; }

        public Order? Order { get; set; }
    }
}