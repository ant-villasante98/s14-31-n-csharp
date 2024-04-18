namespace S14.MenuSystem.Domain
{
    public class Promotion
    {
        public int Id { get; set; }

        required public string Name { get; set; }

        required public string Description { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal SalePrice { get; set; }

        public int ItemId { get; set; }

        required public MenuItem Item { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime EndsAt { get; set; }

        public int Total { get; set; }

        public int Available { get; set; }

        public bool IsActive { get; set; }
    }
}
