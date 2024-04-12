namespace S14.Orders.Common.Exceptions
{
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException(int orderId) 
        : base($"Order with id {orderId} not found")
        {
        }
    }
}