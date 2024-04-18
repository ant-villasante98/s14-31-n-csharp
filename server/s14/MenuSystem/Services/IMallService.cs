using S14.MenuSystem.Common.Dtos;
using S14.MenuSystem.Domain;

namespace S14.MenuSystem.Services
{
    public interface IMallService
    {
        MallResponse? GetMallById(int id);

        ShopResponse? GetShopById(int id);

        IEnumerable<MallResponse> GetAllMalls();

        IEnumerable<ShopResponse> GetAllShopsByMallId(int mallId);
    }
}
