using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using S14.MenuSystem.Services;
using S14.Orders.Common.Dtos;
using S14.Orders.Common.Exceptions;
using S14.Orders.Domain;
using S14.Orders.Domain.Enums;
using S14.Orders.Infrastructure;
using S14.Payments.Common.Dtos;
using S14.Payments.Services;
using S14.QR.Service;

namespace S14.Orders.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPaymentService _paymentService;
        private readonly IQrService _qrService;

        private readonly IShopService _shopService;

        public OrdersService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPaymentService paymentService,
            IQrService qrService,
            IShopService shopService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _paymentService = paymentService;
            _qrService = qrService;
            _shopService = shopService;
        }

        public async Task<int> CreateOrderAsync(CreateOrderDTO createOrderDTO, int userId)
        {
            if (createOrderDTO?.Items.Count == 0)
            {
                // Personalizar Exception
                throw new Exception("Pedido sin Items");
            }

            var order = _mapper.Map<Order>(createOrderDTO);

            // Verificar existencia de items
            var items = _shopService.VerifyStockByItems(order.Details.Select((v) => v.Id).ToArray());
            if (items.Items.Any((v) => !v.IsAvailable))
            {
                throw new ItemsNoStrockException<VerifyResponse>("email", items);
            }

            try
            {
                await _unitOfWork.BeginTransactionAsync();

                // verificar y descontar stock de los items pedidos
                order.UserId = userId;
                order.CreationDate = DateTime.UtcNow;
                order.Status = OrderStatus.Created;

                await _unitOfWork.OrderRepository.AddAsync(order);
                await _unitOfWork.SaveChangesAsync();

                await _unitOfWork.CommitTransactionAsync();
                return order.Id;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }

        public async Task<OrderDTO?> GetOrderAsync(int orderId, int userId)
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
            await _unitOfWork.OrderRepository.UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PaymentResponse> PayOrder(int orderId)
        {
            var order = await _unitOfWork.OrderRepository.GetOrderByIdAsync(orderId);

            // if (order == null)
            // {
            //     throw new Exception(orderId);
            // }
            // if (order != null && order.Status != OrderStatus.Created)
            // {
            //     if (order.Status == OrderStatus.Canceled)
            //     {
            //         throw new Exception("La Orden ya fue cancelada");
            //     }
            //     throw new Exception("La Orden ya fue Pagada");
            // }

            // realizar pago
            var pay = await _paymentService.CreatePayment(order);

            if (pay.IsValid)
            {
                // Descontar items del stock
                order.Status = OrderStatus.Payed;
                await _unitOfWork.OrderRepository.UpdateAsync(order);
                await _unitOfWork.SaveChangesAsync();
            }

            // Notificar Orden paganda
            return pay;
        }

        public async Task AcceptOrder(int orderId)
        {
            var order = await _unitOfWork.OrderRepository.GetOrderByIdAsync(orderId);

            if (order == null)
            {
                throw new OrderNotFoundException(orderId);
            }

            if (order.Status != OrderStatus.Payed)
            {
                // TODO: Personalizar exception
                throw new Exception("La Orden no esta pagada");
            }

            order.Status = OrderStatus.InProgress;
            await _unitOfWork.OrderRepository.UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync();

            // Notificar acceptacion de pedido
        }

        public async Task RegisterOrderReady(int orderId)
        {
            var order = await _unitOfWork.OrderRepository.GetOrderByIdAsync(orderId);

            if (order == null)
            {
                throw new OrderNotFoundException(orderId);
            }

            if (order.Status != OrderStatus.InProgress)
            {
                // TODO: Personalizar exception
                throw new Exception("La Orden no esta aceptada por el local.");
            }

            // Guardando estado
            order.Status = OrderStatus.Prepared;
            await _unitOfWork.OrderRepository.UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync();

            // Creado Qr
            await _qrService.CreateQr(orderId);

            // Notificar pedido listo
        }

        public async Task DeliverOrder(int orderId)
        {
            var order = await _unitOfWork.OrderRepository.GetOrderByIdAsync(orderId);

            if (order == null)
            {
                throw new OrderNotFoundException(orderId);
            }

            if (order.Status != OrderStatus.Prepared)
            {
                // TODO: Personalizar exception
                throw new Exception("La Orden no esta preparada");
            }

            order.Status = OrderStatus.Finished;
            await _unitOfWork.OrderRepository.UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync();

            // Notificar Pedidio entregado
        }

        public async Task CancelOrderAsync(int orderId)
        {
            var order = await _unitOfWork.OrderRepository.GetOrderByIdAsync(orderId);

            if (order == null)
            {
                throw new OrderNotFoundException(orderId);
            }

            // La oreden no debe estar en preparacion o estados posteriores
            if (order.Status is not OrderStatus.Payed && order.Status is not OrderStatus.Created)
            {
                // Personalizar Exception de este caso
                throw new Exception("No se puede cancelar la Orden");
            }

            order.Status = OrderStatus.Canceled;
            await _unitOfWork.OrderRepository.UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync();

            // Notificar pedido cancelado
        }
    }
}