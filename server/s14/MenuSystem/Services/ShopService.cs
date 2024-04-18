using AutoMapper;
using Microsoft.EntityFrameworkCore;
using S14.MenuSystem.Common;
using S14.MenuSystem.Common.Dtos;
using S14.MenuSystem.Controllers;
using S14.MenuSystem.Domain;
using S14.MenuSystem.Infraestructure;
using System.Runtime.Serialization;

namespace S14.MenuSystem.Services
{
    public class ShopService(MenuSystemContext context, IMapper mapper)
        : IShopService
    {
        public MenuItemResponse GetMenuItemById(int itemId)
        {
            var item = context.Items
                .Include(x => x.Category)
                .Where(x => x.Id == itemId)
                .FirstOrDefault();

            item = item ?? throw new ItemNotFoundException(itemId);

            return mapper.Map<MenuItemResponse>(item);
        }

        ///<summary>Get the of a shop</summary>
        /// <exception cref="ShopNotFoundException">when shop no found</exception>
        public IEnumerable<MenuItemResponse> GetMenuByShopId(int shopId)
        {
            var shopMenu = context.Items
                .Include(x => x.Category)
                .Where(x => x.ShopId == shopId);

            if (shopMenu.Any())
            {
                var menu = mapper.Map<IEnumerable<MenuItemResponse>>(shopMenu);
                return menu;
            }

            if (context.Shops.Find(shopId) is null)
            {
                throw new ShopNotFoundException(shopId);
            }

            return Enumerable.Empty<MenuItemResponse>();
        }

        public VerifyResponse VerifyStockByOrder(int orderId)
        {
            var itemsIds = Enumerable.Range(1, 5);
            var res =
                new VerifyResponse(orderId, itemsIds.Select(x => new StockDetail(x, true)));
            return res;
        }

        public VerifyResponse VerifyStockByItems(int[] itemIds)
        {
            var items = context.Items.Where(x => itemIds.Contains(x.Id));
            var res =
                new VerifyResponse(0, items.Select(x => new StockDetail(x.Id, x.IsAvailable)));
            return res;
        }
    }

    public class ItemNotFoundException(int itemId, string message = "", Exception innerException = null)
        : Exception(message, innerException)
    {
        public int ItemId { get; set; }
    }

    public record VerifyResponse(int OrderId, IEnumerable<StockDetail> Items);

    public record StockDetail(int ItemId, bool IsAvailable);
}
