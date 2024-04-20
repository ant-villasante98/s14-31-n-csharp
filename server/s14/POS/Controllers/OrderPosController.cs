using Microsoft.AspNetCore.Mvc;
using S14.Orders.Domain.Enums;
using S14.POS.Services;

namespace S14.POS.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PosController : ControllerBase
{
    private readonly IOrderPosService _orderPosService;

    public PosController(IOrderPosService orderPosService)
    {
        _orderPosService = orderPosService;
    }

    [Obsolete("Not related")]
    [HttpPost("change-order-state")]
    public async Task<IActionResult> ChangeStateToOrder(string qrValue, OrderStatus orderStatus)
    {
        var orderId = await _orderPosService.ValidateQr(qrValue);
        await _orderPosService.ChangeOrderState(orderId, orderStatus);

        return Ok();
    }
}