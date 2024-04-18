using System.Reflection;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using S14.MenuSystem.Infraestructure.DI;
using S14.Orders.Common.Mappers;
using S14.Orders.Infrastructure;
using S14.Orders.Infrastructure.Repositories;
using S14.Orders.Services;
using S14.Payments.Infraestructure.DI;
using S14.POS.Infrastructure;
using S14.QR.Infrastructure.DI;

namespace S14.Base.Infrastructure
{
    public static class BaseDI
    {
        public static void AuthenticationForSignalR(this IServiceCollection services, string hubPath)
        {

            services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme, c =>
            {
                c.BearerTokenExpiration = TimeSpan.FromDays(5);
                c.RefreshTokenExpiration = TimeSpan.FromDays(10);

                c.Events = new BearerTokenEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken)
                            && path.StartsWithSegments(hubPath))
                        {
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }

        public static void AddDomainServices(this IServiceCollection services, [FromServices] IConfiguration configuration)
        {
            services.OrdersSystemServices(configuration);
            services.AddQrDependencyInjection(configuration);
            services.PaymentsSystemServices(configuration);
            services.MenuSystemServices(configuration);
            services.OrderPosServices();
        }
    }
}