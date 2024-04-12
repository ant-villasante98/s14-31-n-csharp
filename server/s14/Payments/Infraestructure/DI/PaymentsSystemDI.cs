using Microsoft.EntityFrameworkCore;
using S14.Payments.Common.Mappers;
using S14.Payments.Services;

namespace S14.Payments.Infraestructure.DI
{
    public static class PaymentsSystemDI
    {
        public static void PaymentsSystemServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PaymentsSystemContext>(options => options.UseSqlServer(configuration.GetConnectionString("CS")));

            // services.AddScoped<PaymentsSystemContext>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddAutoMapper(typeof(PaymentsMapperProfile));
        }
    }
}
