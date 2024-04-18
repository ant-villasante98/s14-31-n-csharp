using S14.MenuSystem.Domain;
using System.Collections.ObjectModel;

namespace S14.MenuSystem.Common.Dtos
{
    public class ShopResponse
    {
        public int Id { get; init; }

        required public int MallId { get; init; }

        public string? Name { get; init; }

        public string? Description { get; init; }

        public string? Address { get; init; }

        public Uri? ImageUrl { get; init; }

        public Uri? BannerUrl { get; init; }

        public TimeOnly OpensAt { get; init; }

        public TimeOnly ClosesAt { get; init; }

        public Collection<string>? Categories { get; init; }

        public Collection<MenuItemResponse>? Menu { get; init; }

        public Collection<Promotion>? Promotions { get; init; }

        public Collection<int>? AgentIds { get; init; }
    }
}
