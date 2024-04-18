namespace S14.MenuSystem.Common.Dtos
{
    public class MenuItemResponse
    {
        public int Id { get; set; }

        public int ShopId { get; set; }

        required public string Category { get; set; }

        required public string Name { get; set; }

        required public string Description { get; set; }

        public decimal Price { get; set; }

        required public Uri ImageUrl { get; set; }

        public bool IsAvailable { get; set; }
    }
}
