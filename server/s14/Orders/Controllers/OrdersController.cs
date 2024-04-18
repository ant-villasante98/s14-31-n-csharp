using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using S14.MenuSystem.Controllers;
using S14.Orders.Common.Dtos;
using S14.Orders.Common.Exceptions;
using S14.Orders.Services;
using S14.Payments.Common.Dtos;

namespace S14.Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDTO orderDTO)
        {
            int userId;
            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out userId))
            {
                return Unauthorized();
            }
            try
            {
                var orderId = await _ordersService.CreateOrderAsync(orderDTO, userId);
                return Ok(orderId);
            }
            catch (ItemsNoStrockException<VerifyResponse> ex)
            {
                return BadRequest(ex.Value);
            }

        }

        [Authorize]
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            int userId;
            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out userId))
            {
                return Unauthorized();
            }

            var order = await _ordersService.GetOrderAsync(orderId, userId);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [Authorize]
        [HttpPut("{orderId}/pay")]
        public async Task<ActionResult<PaymentResponse>> PayOrder(int orderId)
        {
            // pagar Order
            var pay = await _ordersService.PayOrder(orderId);

            return Ok(pay);
        }

        [Authorize]
        [HttpPut("{orderId}/prepare")]
        public async Task<IActionResult> PrepareOrder(int orderId)
        {
            await _ordersService.AcceptOrder(orderId);

            return NoContent();
        }

        [Authorize]
        [HttpPut("{orderId}/ready-to-deliver")]
        public async Task<IActionResult> OrderReady(int orderId)
        {
            await _ordersService.RegisterOrderReady(orderId);

            return NoContent();
        }

        [Authorize]
        [HttpPut("{orderId}/finish")]
        public async Task<IActionResult> FinishOrder(int orderId)
        {
            await _ordersService.DeliverOrder(orderId);

            return NoContent();
        }

        [Authorize]
        [HttpPut("{orderId}/cancel")]
        public async Task<IActionResult> CancelOrder(int orderId)
        {
            await _ordersService.CancelOrderAsync(orderId);

            return NoContent();
        }
    }
}
