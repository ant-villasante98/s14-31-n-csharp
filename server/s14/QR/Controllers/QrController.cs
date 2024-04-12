using System.Web;
using System.Xml;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using S14.QR.Commmon.Dtos;
using S14.QR.Domain;
using S14.QR.Service;

namespace S14.QR.Controllers;

[ApiController]
[Route("api/qr")]
public class QrController : ControllerBase
{
    private readonly IQrService _service;

    public QrController(IQrService service)
    {
        _service = service;
    }

    /// <summary>
    /// Busca o genera y guarda en la DB el Qr en base al id de la Orden .
    /// </summary>
    /// <returns>Un SVG codificado como texto.</returns>
    /// <exception cref="ArgumentNullException">OrderId debe ser un entrero.</exception>
    /// <remarks>
    /// Se puede generar un qr de cualquier numero natural.
    /// </remarks>
    [HttpPut("generate-qr/{orderId}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<ActionResult<QrResponse>> CreateQr(int orderId)
    {
        string result = await _service.GetSvgByOrderId(orderId);
        if (result.IsNullOrEmpty())
        {
            Qr qrResult = await _service.CreateQr(orderId);
            result = qrResult.SvgValue;
        }

        QrResponse response = new QrResponse()
        {
            SvgValue = HttpUtility.HtmlEncode(result),
            CodeValue = "hola"
        };

        // return Ok(HttpUtility.UrlEncode(result));
        return Ok(response);
    }

    /// <summary>
    /// Decodifica y obtiene el id de la Order.
    /// </summary>
    /// <returns>Un QR en SVG codificado.</returns>
    /// <exception cref="ArgumentNullException">QrCheckRequest es null.</exception>
    /// <remarks>
    /// Se ingresa el text que se optine al escanear el QR.
    /// </remarks>
    [HttpPost("check-code")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<ActionResult<int>> ValidateQr([FromBody] QrCheckRequest qrCheck)
    {
        int result = await _service.CheckOrderByQr(qrCheck.Value);

        return Ok(result);
    }

    /// <summary>
    /// Obtiene el svg por el id de Order.
    /// </summary>
    /// <returns>Un SVG</returns>
    /// <exception cref="ArgumentNullException">orderId no es un numero natural.</exception>
    /// <remarks>
    /// El resultado es un SVG(no texto).
    /// </remarks>
    [HttpGet("get-svg/{orderId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetQr(int orderId)
    {
        string result = await _service.GetSvgByOrderId(orderId);
        if (result.IsNullOrEmpty())
        {
            return NotFound();
        }

        return Content(result, "image/svg+xml");
    }
}
