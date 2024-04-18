using Microsoft.EntityFrameworkCore;
using S14.MenuSystem.Infraestructure;
using S14.Orders.Infrastructure;
using S14.Payments.Infraestructure;
using S14.QR.Infrastructure.EntityFramework.Persistance;

namespace S14.Base.Infrastructure.Data
{
    public static class SchemasExtensions
    {
        public static void CreateSchemas(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            using Context identityContext = scope.ServiceProvider.GetRequiredService<Context>();
            identityContext.Database.EnsureCreated();

            using MenuSystemContext mSContext = scope.ServiceProvider.GetRequiredService<MenuSystemContext>();
            mSContext.Database.Migrate();

            using OrdersSystemContext osContext = scope.ServiceProvider.GetRequiredService<OrdersSystemContext>();
            mSContext.Database.Migrate();

            using PaymentsSystemContext psContext = scope.ServiceProvider.GetRequiredService<PaymentsSystemContext>();
            mSContext.Database.Migrate();

            using QrSystemContext qrContext = scope.ServiceProvider.GetRequiredService<QrSystemContext>();
            mSContext.Database.Migrate();
        }
    }
}
