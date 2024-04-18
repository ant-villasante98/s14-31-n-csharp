using Microsoft.AspNetCore.Mvc;
using S14.Orders.Infrastructure.Repositories;
using S14.Payments.Common.Dtos;
using S14.Payments.Services;

namespace S14.Payments.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController(IPaymentService _paymentService, IOrderRepository _orderRepository)
        : ControllerBase
    {


        /// <summary>
        /// Crea el pago de una orden a traves del Id de la misma.
        /// </summary>
        /// <returns>Respuesta del pago, haya sido exitoso o no dicho pago.</returns>
        /// <param name="orderId"></param>
        // [HttpPost]
        // [ProducesResponseType<PaymentResponse>(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status404NotFound)]
        // public async Task<ActionResult<PaymentResponse>> CreatePayment(int orderId)
        // {
        //     var paymentResponse = await _paymentService.CreatePayment(orderId);
        //     return paymentResponse is null ? NotFound("Payment creation failed") : Ok(paymentResponse);
        // }

        [HttpPost]
        [ProducesResponseType<PaymentResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PaymentResponse>> CreatePayment(int orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            var paymentResponse = await _paymentService.CreatePayment(order);
            return paymentResponse is null ? NotFound("Payment creation failed") : Ok(paymentResponse);
        }
    }
}
