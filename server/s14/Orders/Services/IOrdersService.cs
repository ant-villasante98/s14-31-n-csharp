using S14.Orders.Common.Dtos;
using S14.Orders.Domain;
using S14.Orders.Domain.Enums;

namespace S14.Orders.Services
{
    public interface IOrdersService
    {
        Task<int> CreateOrderAsync(CreateOrderDTO createOrderDTO, int userId);

        Task<OrderDTO> GetOrderAsync(int orderId, int userId);

        Task<IEnumerable<OrderDTO>> GetOrdersAsync(int userId);

        Task UpdateOrderStatusAsync(int orderId, OrderStatus newState);

        Task CancelOrderAsync(int orderId);
    }
}