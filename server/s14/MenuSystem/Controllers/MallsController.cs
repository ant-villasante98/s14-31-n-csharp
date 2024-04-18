using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using S14.Base.Infraestructure.Data;
using S14.MenuSystem.Common;
using S14.MenuSystem.Common.Dtos;
using S14.MenuSystem.Domain;
using S14.MenuSystem.Services;

namespace S14.MenuSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MallsController(IMallService mallService)
        : ControllerBase
    {
        // GET: api/<MallsController>/Search
        /// <summary>
        /// Basado en el termino de busqueda devuelve los Shops con los Items de un menu si el termino esta contenido en el nombre.
        /// </summary>
        /// <remarks>
        /// La busqueda es case insentitive. <br/>
        /// Si el termino es vacio o nulo devuelve un arreglo vacio.
        /// 
        /// <para>
        /// 
        /// deprecated result
        /// La busqueda devuelve un arreglo de  SearchResultItem. <br/>
        /// </para>
        /// 
        /// Ejemplo:
        /// 
        ///     [
        ///         {
        ///    "mallId": 0,
        ///    "shopId": 0,
        ///    "name": "string",
        ///    "description": "string",
        ///    "address": "string",
        ///    "imageUrl": "string",
        ///    "bannerUrl": "string",
        ///    "menuFilteredResults": [
        ///      {
        ///        "id": 0,
        ///        "category": "string",
        ///        "name": "string",
        ///        "description": "string",
        ///        "price": 0,
        ///        "imageUrl": "string",
        ///        "isAvailable": true
        ///      }
        ///    ]
        ///  }
        ///]
        /// </remarks>
        /// <param name="term">El termino a buscar</param>
        /// <returns>SearchGroupedResponse</returns>
        [HttpGet("search")]
        [ProducesResponseType<SearchGroupedResponse>(StatusCodes.Status200OK)]
        public async Task<ActionResult<SearchGroupedResponse>> Search([FromQuery] string? term, [FromServices] ISearchService ss)
        {
            return string.IsNullOrEmpty(term)
                ? new SearchGroupedResponse()
                : await ss!.Search(term);
        }

        // GET: api/<MallsController>
        [HttpGet]
        [ProducesResponseType<IEnumerable<MallResponse>>(StatusCodes.Status200OK)]
        public IEnumerable<MallResponse> Get() => mallService.GetAllMalls();

        // GET api/<MallsController>/5
        [HttpGet("{id}")]
        public ActionResult<Mall> GetById(int id)
        {
            var mall = mallService.GetMallById(id);
            return mall is null ? NotFound() : Ok(mall);
        }

        [HttpGet("{mallId}/shops")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType<IEnumerable<Shop>>(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Shop>> GetShops(int mallId)
        {
            try
            {
                return Ok(mallService.GetAllShopsByMallId(mallId));
            }
            catch (MallNotFoundException)
            {
                return NotFound();
            }
        }

        // GET api/<MallsController>/shops/5
        [HttpGet("/api/shops/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType<Shop>(StatusCodes.Status200OK)]
        public ActionResult<Shop> GetShopById(int id)
        {
            var shop = mallService.GetShopById(id);
            return shop is null ? NotFound() : Ok(shop);
        }

        [HttpGet("/api/shops/{shopId}/menu")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType<IEnumerable<Shop>>(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<MenuItemResponse>> GetMenu(int shopId, [FromServices] IShopService shopService)
        {
            try
            {
                return Ok(shopService.GetMenuByShopId(shopId));
            }
            catch (Exception)
            {
                // requiere una excepcion especifica segun el caso o Global
                return NotFound();
            }
        }

        [HttpGet("/api/shops/menu/{itemId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType<IEnumerable<Shop>>(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<MenuItemResponse>> GetMenuItem(int itemId, [FromServices] IShopService shopService)
        {
            try
            {
                return Ok(shopService.GetMenuItemById(itemId));
            }
            catch (Exception) // requiere una excepcion especifica segun el caso o Global
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Obtiene la disponibilidad de los items correspondientes a una orden
        /// </summary>
        /// <remarks>
        /// Ejemplo de respuesta:
        /// 
        ///     {
        ///          "orderId": 1,
        ///          "items": 
        ///          [
        ///             {
        ///                 "itemId": 1,
        ///                 "isAvailable": true
        ///             },...
        ///          ]
        ///      }
        /// </remarks>
        /// <param name="orderId"></param>
        /// <returns>VerifyResponse</returns>
        [HttpPost("/api/shops/verify-stock-by-order")]
        public ActionResult<VerifyResponse> VerifyStockByOrderId(int orderId, [FromServices] IShopService shopService)
        {
            return Ok(shopService.VerifyStockByOrder(orderId));

        }

        [HttpPost("/api/shops/verify-stock-by-items")]
        public ActionResult<VerifyResponse> VerifyStockByItemsId(int[] itemIds, [FromServices] IShopService shopService)
        {
            return Ok(shopService.VerifyStockByItems(itemIds));
        }
    }

    public record VerifyResponse(int OrderId, IEnumerable<StockDetail> Items);

    public record StockDetail(int ItemId, bool IsAvailable);

}
