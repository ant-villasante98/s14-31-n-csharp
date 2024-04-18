namespace S14.MenuSystem.Domain
{
    public class Mall
    {
        public int Id { get; set; }

        required public string Name { get; set; }

        public string? Description { get; set; }

        public string? Address { get; set; }

        public Uri? ImageUrl { get; set; }

        public TimeOnly OpensAt { get; set; }

        public TimeOnly ClosesAt { get; set; }

        public List<Shop>? Shops { get; set; }
    }
}
