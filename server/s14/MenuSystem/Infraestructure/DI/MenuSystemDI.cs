using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S14.MenuSystem.Controllers;
using S14.MenuSystem.Services;

namespace S14.MenuSystem.Infraestructure.DI
{
    public static class MenuSystemDI
    {
        public static void MenuSystemServices(this IServiceCollection services, [FromServices] IConfiguration configuration)
        {
            services.AddDbContext<MenuSystemContext>(options => options.
                UseSqlServer(configuration.GetConnectionString("CS")));

            services.AddScoped<MenuSystemContext>();

            services.AddScoped<IMallService, MallService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IShopService, ShopService>();
        }
    }
}
