using S14.POS.Services;

namespace S14.POS.Infrastructure;
public static class OrderPosDependencies
{
    public static void OrderPosServices(
        this IServiceCollection services)
    {
        services.AddScoped<IOrderPosService, OrderPosService>();
      //  services.AddSignalR(config => config.EnableDetailedErrors = true);

        // services.AddAutoMapper(typeof(PosMapper));
    }
}
