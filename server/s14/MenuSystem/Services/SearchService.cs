using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S14.MenuSystem.Common.Dtos;
using S14.MenuSystem.Infraestructure;

namespace S14.MenuSystem.Services
{
    public class SearchService([FromServices] MenuSystemContext context)
        : ISearchService
    {
        public async Task<SearchResponse> Search(string term, int? mallId = null, int? shopId = null, int? categoryId = null)
        {
            // malls
            var mallsResult = await context.Malls
                .Where(x => x.Name.Contains(term))
                .Select(x => new SearchResultItem(x.Name, "Mall", $"malls/{x.Id}/"))
                .ToListAsync();

            var shopsResult = await context.Shops
                .Where(x => x.Name.Contains(term))
                .Select(x => new SearchResultItem(x.Name, "Shop", $"malls/shops/{x.Id}"))
                .ToListAsync();

            var itemsResult = await context.Items.Include(x => x.Shop)
               .Where(x => x.Name.Contains(term)
               || x.Description.Contains(term)).Select(x =>
               new SearchResultItem(x.Name, "Item", $"malls/{x.Shop.MallId}/shops/{x.ShopId}/menu/{x.Id}"))
               .ToListAsync();

            // Devuelvo los Items que estan en esa categoria
            var categoryResult = await context.Items.Include(i => i.Category)
                .Include(i => i.Shop).ThenInclude(x => x.MallId)
                .Where(x => x.Category.Name.Contains(term))
                .Select(it => new SearchResultItem(it.Name, "Category", $"malls/{it.Shop.MallId}/shops/{it.ShopId}/menu/{it.Id}))"))
                .ToListAsync();

            // Los shops que tiene alimentos en esas categorias
            var shopsInSomeCategory = await context.Items
                .Include(i => i.Category)
                .Include(i => i.Shop).ThenInclude(x => x.MallId)
                .Where(x => x.Category.Name.Contains(term))
                .Select(x => x.Shop)
                .Select(shop => new SearchResultItem(shop.Name, "Category", $"malls/{shop.MallId}/shops/{shop.Id}"))
                .ToListAsync();

            var allResults = mallsResult
                .Concat(shopsResult)
                .Concat(itemsResult)
                .Concat(categoryResult)
                .Concat(shopsInSomeCategory);

            var result = new SearchResponse();
            result.AddRange(allResults);

            return result;
        }

        public async Task<SearchGroupedResponse> Search(string term)
        {
            var allShops = await context.Shops
                .Include(x => x.Menu)
                .ThenInclude(x => x.Category)

                // Need improvement
                .Where(shop => shop.Name.Contains(term)
                || shop.Menu.Any(item => item.Name.Contains(term))
                || shop.Menu.Any(item => item.Category.Name.Contains(term)))

                .Select(x => new SearchGroupedByShopResult()
                {
                    MallId = x.MallId,
                    ShopId = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Address = x.Address,
                    BannerUrl = x.BannerUrl,
                    ImageUrl = x.ImageUrl,
                    Categories = x.Menu.Select(x => x.Category.Name).Distinct().ToArray(),

                    // add  mapper
                    MenuFilteredResults = x.Menu
                    .Where(i => i.Name.Contains(term)
                    || i.Category.Name.Contains(term))
                    .Select(item => new MenuItemResponse()
                    {
                        Category = item.Category.Name,
                        Name = item.Name,
                        Description = item.Description,
                        ImageUrl = item.ImageUrl,
                        Price = item.Price,
                        IsAvailable = item.IsAvailable
                    }).ToArray()

                }).ToListAsync();

            var res = new SearchGroupedResponse();
            res.AddRange(allShops);
            return res;
        }
    }
}
