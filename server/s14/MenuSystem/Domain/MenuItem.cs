namespace S14.MenuSystem.Domain
{
    public class MenuItem
    {
        public int Id { get; set; }

        required public int CategoryId { get; set; }

        required public int ShopId { get; set; }

        public Shop Shop { get; set; }

        public MenuItemCategory Category { get; set; }

        required public string Name { get; set; }

        required public string Description { get; set; }

        public decimal Price { get; set; }

        required public Uri ImageUrl { get; set; }

        public bool IsAvailable { get; set; }
    }
}
