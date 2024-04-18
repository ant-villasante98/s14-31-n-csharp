using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using S14.Orders.Domain.Enums;
using S14.Orders.Services;

namespace S14.Base.Controllers.Hubs;

public class OrderPosHub(IOrdersService _orderService)
    : Hub
{
    public async Task SendMessage(string content)
    {
        await Clients.All.SendAsync("OrderStatusUpdated", content);
    }

    public async Task UpdateOrderState(int orderId, OrderStatus newStatus)
    {
        var user = GetCurrenUser() ?? "invited";
        await _orderService.UpdateOrderStatusAsync(orderId, newStatus);
        await Clients.All.SendAsync("OrderStatusUpdated", $"{user}:{orderId}:{newStatus.ToString()}");
    }

    public override async Task OnConnectedAsync()
    {
        var user = GetCurrenUser() ?? "invited";
        await Clients.All.SendAsync("LoggedIn", $"{user}");
        await base.OnConnectedAsync();
    }

    private string? GetCurrenUser()
    {
        var user = Context.User.Identity.IsAuthenticated ? Context.User.Identity.Name : null;
        return user;
    }

}
