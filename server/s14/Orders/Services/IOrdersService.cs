using S14.Orders.Common.Dtos;
using S14.Orders.Domain;
using S14.Orders.Domain.Enums;
using S14.Payments.Common.Dtos;

namespace S14.Orders.Services
{
    public interface IOrdersService
    {
        Task<int> CreateOrderAsync(CreateOrderDTO createOrderDTO, int userId);

        Task<OrderDTO?> GetOrderAsync(int orderId, int userId);

        Task<IEnumerable<OrderDTO>> GetOrdersAsync(int userId);

        Task UpdateOrderStatusAsync(int orderId, OrderStatus newState);

        Task<PaymentResponse> PayOrder(int orderId);

        Task AcceptOrder(int orderId);

        Task RegisterOrderReady(int orderId);

        Task DeliverOrder(int orderId);

        Task CancelOrderAsync(int orderId);
    }
}