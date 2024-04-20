using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.SignalR;
using S14.Orders.Domain.Enums;
using S14.Orders.Services;

namespace S14.Base.Controllers.Hubs;

public class NotificationsHub(IOrdersService _orderService, SignalRConnectionsContext _context)
    : Hub
{
    public async Task SendMessage(string content, int i)
    {
        await Clients.All.SendAsync("OrderStatusUpdated", content);
    }

    public async Task UpdateOrderState(int orderId, OrderStatus newStatus)
    {
        var user = GetCurrenUser() ?? "guest";
        await _orderService.UpdateOrderStatusAsync(orderId, newStatus);
        await Clients.All.SendAsync("OrderStatusUpdated", $"{user}:{orderId}:{newStatus.ToString()}");
    }

    public override async Task OnConnectedAsync()
    {
        var user = GetCurrenUser() ?? "guest";
        await Clients.Client(Context.ConnectionId).SendAsync("Welcome", $"{user}");

        var feature = Context.Features.Get<IHttpConnectionFeature>();

        if (!user.Equals("guest"))
        {
            var conn = _context.Connections.Where(x => x.UserName == user).FirstOrDefault()
                ?? new HubConnection()
                {
                    IsActive = true,
                    StartedAt = DateTime.Now,
                    UserName = user,
                    ConnectionId = this.Context.ConnectionId,
                    LastIp = feature!.RemoteIpAddress!.ToString() ?? string.Empty
                };

            if (conn.Id == 0)
            {
                _context.Connections.Add(conn);
            }
            else
            {
                conn.IsActive = true;
                conn.ConnectionId = Context.ConnectionId;
                conn.LastIp = feature!.RemoteIpAddress!.ToString() ?? string.Empty;
                _context.Entry(conn).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var connId = this.Context.ConnectionId;

        var conn = _context.Connections.FirstOrDefault(x => x.ConnectionId == connId);

        // El usuario no es invitado
        if (conn is not null)
        {
            conn.IsActive = false;
            _context.Connections.Update(conn);
            await _context.SaveChangesAsync();
        }
    }

    private string? GetCurrenUser()
    {
        var user = Context!.User!.Identity!.IsAuthenticated ? Context.User.Identity.Name : null;
        return user;
    }

}
