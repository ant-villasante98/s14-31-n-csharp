using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using S14.Base.Controllers.Hubs;
using S14.MenuSystem.Infraestructure.DI;
using S14.Orders.Infrastructure;
using S14.Payments.Infraestructure.DI;
using S14.POS.Infrastructure;
using S14.QR.Infrastructure.DI;
using System.Reflection;

namespace S14.Base.Infrastructure
{
    public static class BaseDI
    {
        public static void AuthenticationForSignalR(this IServiceCollection services, string hubPath)
        {
            services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme, c =>
            {
                c.BearerTokenExpiration = TimeSpan.FromDays(50);
                c.RefreshTokenExpiration = TimeSpan.FromDays(50);

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

            services.AddScoped<SignalRConnectionsContext>();
        }

        public static void ConfigureSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() { Title = "NoWait" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Scheme = "Bearer",
                    Description = "Ingresa  solo el {token}, pero cuando estes llamando desde postman o la app, debes agregar => Bearer {token}",
                    Type = SecuritySchemeType.Http,
                    In = ParameterLocation.Header,
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
            });
        }
    }
}