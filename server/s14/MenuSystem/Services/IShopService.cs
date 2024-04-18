using S14.MenuSystem.Common.Dtos;
using S14.MenuSystem.Domain;

namespace S14.MenuSystem.Services
{
    public interface IShopService
    {
        IEnumerable<MenuItemResponse> GetMenuByShopId(int shopId);

        MenuItemResponse GetMenuItemById(int itemId);

        VerifyResponse VerifyStockByOrder(int orderId);

        VerifyResponse VerifyStockByItems(int[] itemsIds);
    }
}
