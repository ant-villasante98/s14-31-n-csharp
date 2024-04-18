using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S14.Orders.Common.Mappers;
using S14.Orders.Infrastructure.Repositories;
using S14.Orders.Services;

namespace S14.Orders.Infrastructure
{
    public static class OrdersSystemDI
    {
        public static void OrdersSystemServices(this IServiceCollection services, [FromServices] IConfiguration configuration)
        {
            services.AddDbContext<OrdersSystemContext>(options => options.UseSqlServer(configuration.GetConnectionString("CS")));

            services.AddScoped<OrdersSystemContext>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}