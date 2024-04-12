using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using S14.Orders.Common.Dtos;
using S14.Orders.Common.Exceptions;
using S14.Orders.Domain;
using S14.Orders.Domain.Enums;
using S14.Orders.Infrastructure;

namespace S14.Orders.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrdersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> CreateOrderAsync(CreateOrderDTO createOrderDTO, int userId)
        {
            var order = _mapper.Map<Order>(createOrderDTO);
            order.UserId = userId;
            order.CreationDate = DateTime.UtcNow;
            order.Status = OrderStatus.Created;

            await _unitOfWork.OrderRepository.AddAsync(order);
            await _unitOfWork.CommitAsync();

            return order.Id;
        }

        public async Task<OrderDTO> GetOrderAsync(int orderId, int userId)
        {
            var order = await _unitOfWork.OrderRepository.GetOrderByIdAsync(orderId);

            if (order == null || order.UserId != userId)
            {
                return null;
            }

            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersAsync(int userId)
        {
            var orders = await _unitOfWork.OrderRepository.GetOrdersAsync(userId);
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task UpdateOrderStatusAsync(int orderId, OrderStatus newState)
        {
            var order = await _unitOfWork.OrderRepository.GetOrderByIdAsync(orderId);

            if (order == null)
            {
                throw new OrderNotFoundException(orderId);
            }

            order.Status = newState;
            await _unitOfWork.CommitAsync();
        }

        public async Task CancelOrderAsync(int orderId)
        {
            var order = await _unitOfWork.OrderRepository.GetOrderByIdAsync(orderId);

            if (order == null)
            {
                throw new OrderNotFoundException(orderId);
            }

            order.Status = OrderStatus.Canceled;
            await _unitOfWork.CommitAsync();
        }
    }
}