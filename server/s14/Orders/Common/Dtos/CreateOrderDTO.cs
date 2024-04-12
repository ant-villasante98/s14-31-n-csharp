namespace S14.Orders.Common.Dtos
{
    public class CreateOrderDTO
    {
        public int LocalId { get; set; }
        public List<DetailOrderDTO> Items { get; set; }
    }
}