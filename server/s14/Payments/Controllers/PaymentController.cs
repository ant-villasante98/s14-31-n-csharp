using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S14.Payments.Common.Dtos;
using S14.Payments.Domain;
using S14.Payments.Services;

namespace S14.Payments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController(IPaymentService _paymentService)
        : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<PaymentResponse>> CreatePayment([FromRoute] int orderId)
        {
            var paymentResponse = await _paymentService.CreatePayment(orderId);
            return Ok(paymentResponse);
        }
    }
}
