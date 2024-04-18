using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using S14.MenuSystem.Common;
using S14.MenuSystem.Common.Dtos;
using S14.MenuSystem.Controllers;
using S14.MenuSystem.Domain;
using S14.MenuSystem.Infraestructure;

namespace S14.MenuSystem.Services
{
    // TODO cast to response
    public class MallService(MenuSystemContext context, IMapper _mapper)
        : IMallService
    {
        public IEnumerable<MallResponse> GetAllMalls()
        {
            var ititems = context.Malls
                .Include(x => x.Shops)
                .ToList();

            return _mapper.Map<List<MallResponse>>(ititems);
        }

        public MallResponse? GetMallById(int id)
        {
            var mall = context.Malls
                .Include(x => x.Shops)
                .ThenInclude(x => x.Menu)
                .ThenInclude(x => x.Category)
                .FirstOrDefault(x => x.Id == id);

            if (mall == null) return null;

            var res = _mapper.Map<MallResponse>(mall);
            res.Shops!.ForEach(x => x.Menu!.Clear());
            
            return res;
        }

        public IEnumerable<ShopResponse> GetAllShopsByMallId(int mallId)
        {
            var mallShops = context.Shops
                .Include(x => x.Menu)
                .ThenInclude(x => x.Category)
                .Where(x => x.MallId == mallId);

            if (mallShops.Any())
            {
                var mapped = _mapper.Map<List<ShopResponse>>(context.Shops
                    .Where(x => x.MallId == mallId));

                // Esto puede ser un campo Json para no tener que consultarlo, t generado acad vez que se agrega un item al menu
                foreach (var shop in mapped)
                {
                    shop.Categories.AddRange(context.Items.Include(x => x.Category)
                        .Where(x => x.ShopId == shop.Id)
                        .Select(x => x.Category.Name)
                        .Distinct()
                        .ToArray());
                }

                return mapped;
            }

            var mallExists = context.Malls.Any(x => x.Id == mallId);
            return mallExists ? Enumerable.Empty<ShopResponse>() : throw new MallNotFoundException(mallId);

        }

        public ShopResponse? GetShopById(int id)
        {
            var shop = context.Shops
                .Include(x => x.Menu).
                ThenInclude(x => x.Category)
                .FirstOrDefault(x => x.Id == id);

            if (shop == null) return null;

            return _mapper.Map<ShopResponse>(shop);
        }
    }
}
