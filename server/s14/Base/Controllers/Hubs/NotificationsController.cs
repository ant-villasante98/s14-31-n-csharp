using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.Elfie.Model;
using Microsoft.EntityFrameworkCore;
using S14.Orders.Domain.Enums;

namespace S14.Base.Controllers.Hubs
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController(IHubContext<NotificationsHub> _hub, SignalRConnectionsContext _context)
        : ControllerBase
    {
        /// <summary>
        /// Envia un mensaje a todos los clientes actualmente conectados
        /// </summary>
        /// <param name="message">el mensaje</param>
        /// <returns>mensaje con el resultado</returns>
        [HttpPost("Notify-all-users")]
        public ActionResult NotifyAll(string message)
        {
            var activeConnsCount = _context.Connections.Count(x => x.IsActive);
            _hub.Clients.All.SendAsync("Test", message);
            return Ok($"Sent to {activeConnsCount} active registered users, and all guests");
        }

        /// <summary>
        /// Enviar un mensaje de notificacion a un usuario especifico
        /// </summary>
        /// <param name="userName">el email del usuario</param>
        /// <param name="message">el mensaje</param>
        /// <returns>un texto con el resultado</returns>
        [HttpPost("Notify-user-by-email")]
        public async Task<ActionResult> NotifyUser(string userName, string message)
        {
            var conn = await _context.Connections.FirstOrDefaultAsync(x => x.UserName == userName);
            if (conn == null) { return NotFound($"{userName} is not  currently connected"); }
            if (!conn.IsActive) { return NotFound($"{userName} doesnt have an active connection"); }

            await _hub.Clients.Client(conn.ConnectionId).SendAsync("Test", message);
            return Ok("Sent");
        }

        /// <summary>
        /// Envia notificaciones segun el estado de la ordern
        /// </summary>
        /// <remarks>
        /// Este endpoint es solo para pruebas, asi que el numero de orden no se valida
        /// <br></br>
        /// <para>
        /// Usa al usuario admin como receptor de las notificaciones
        /// Los estados posibles son:
        /// <code>
        ///         Created = 0, // Orden creada
        ///         Payed = 1, // Orden pagada
        ///         InProgress = 2, // Orden Aceptada por el local
        ///         Prepared = 3, // Order Preparada por el local 
        ///         Finished = 4, // Orden entregada al cliente
        ///         Canceled = 5 // Orden 
        ///     </code>
        /// </para>
        /// </remarks>
        /// <param name="orderId">El numero de orden</param>
        /// <param name="orderStatus">el estado</param>
        [Authorize]
        [HttpPost("change-state")]
        public async Task<IActionResult> ChangeState(string orderId, OrderStatus orderStatus)
        {
            var userName = User.Identity.Name;
            var userConnection = (await _context.Connections.FirstOrDefaultAsync(x => x.UserName.Equals(userName))) 
                ?? null;

            if (userConnection is null) { return NotFound(); }
            await _hub.Clients
                .Client(userConnection.ConnectionId)
                .SendAsync("OrderStatusUpdated", userConnection.UserName, orderId, orderStatus.ToString());

            return Ok();
        }
    }
}
