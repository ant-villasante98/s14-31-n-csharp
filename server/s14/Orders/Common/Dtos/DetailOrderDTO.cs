namespace S14.Orders.Common.Dtos
{
    public class DetailOrderDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}