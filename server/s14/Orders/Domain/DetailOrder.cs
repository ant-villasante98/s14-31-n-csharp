namespace S14.Orders.Domain
{
    public class DetailOrder
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public Order? Order { get; set; }
    }
}