using Microsoft.AspNetCore.SignalR;
using S14.Base.Controllers.Hubs;
using S14.Orders.Common.Exceptions;
using S14.Orders.Domain.Enums;
using S14.Orders.Services;
using S14.QR.Service;

namespace S14.POS.Services;

public class OrderPosService : IOrderPosService
{
    private readonly IHubContext<OrderPosHub> _hubOrderPosContext;
    private readonly IOrdersService _ordersService;
    private readonly IQrService _qrService;

    public OrderPosService(
        IOrdersService ordersService,
        IQrService qrService,
        IHubContext<OrderPosHub> hubOrderPosContext)
    {
        _ordersService = ordersService;
        _hubOrderPosContext = hubOrderPosContext;
        _qrService = qrService;
    }

    /// <summary>
    /// Change the order state and notify client using signalR
    /// </summary>
    public async Task ChangeOrderState(int orderId, OrderStatus status)
    {
        int order = orderId;
        try
        {
            await _ordersService.UpdateOrderStatusAsync(orderId, status);
            await _hubOrderPosContext.Clients.All.SendAsync("OrderStatusUpdated", order);
        }
        catch (OrderNotFoundException ex)
        {
            
            await _hubOrderPosContext.Clients.All.SendAsync("OrderStatusUpdated", order);
        }
    }

    public async Task<int> ValidateQr(string qrValue)
    {
        var checkOrder = await _qrService.CheckOrderByQr(qrValue);
        return checkOrder;
    }
}
