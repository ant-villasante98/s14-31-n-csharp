namespace S14.MenuSystem.Domain
{
    public class Shop
    {
        public int Id { get; set; }

        required public int MallId { get; set; }

        public Mall Mall { get; set; }

        public int AdminId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public Uri ImageUrl { get; set; }

        public Uri BannerUrl { get; set; }

        public TimeOnly OpensAt { get; set; }

        public TimeOnly ClosesAt { get; set; }

        public List<MenuItem> Menu { get; set; } = new ();

        public List<Promotion>? Promotions { get; }

        public List<int>? AgentIds { get; set; }
    }
}
