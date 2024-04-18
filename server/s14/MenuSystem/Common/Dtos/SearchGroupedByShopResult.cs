using S14.MenuSystem.Domain;

namespace S14.MenuSystem.Common.Dtos
{
    public class SearchGroupedByShopResult
    {
        required public int MallId { get; set; }

        public int ShopId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public Uri ImageUrl { get; set; }

        public Uri BannerUrl { get; set; }

        public ICollection<string> Categories { get; set; }

        public ICollection<MenuItemResponse> MenuFilteredResults { get; set; }
    }


    public class SearchGroupedResponse : List<SearchGroupedByShopResult> { }
}
