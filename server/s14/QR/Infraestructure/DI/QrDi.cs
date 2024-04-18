using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using S14.QR.Domain;
using S14.QR.Infrastructure.EntityFramework.Persistance;
using S14.QR.Infrastructure.EntityFramework.Repositories;
using S14.QR.Infrastructure.MongoDB.Configuration;
using S14.QR.Infrastructure.MongoDB.PersistanceMongo;
using S14.QR.Infrastructure.MongoDB.Repositories;
using S14.QR.Service;

namespace S14.QR.Infrastructure.DI;

public static class QrDi
{
    public static IServiceCollection AddQrDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        // Configuracion mongo
        // services.AddMongoDB(configuration);
       // services.AddScoped<IQrRepository, QrRepositoryMongoDB>();

        // Configuracion para EntityFramework
        services.AddDbContext<QrSystemContext>(options => options.UseSqlServer(configuration.GetConnectionString("CS")));
        services.AddScoped<QrSystemContext>();
        services.AddScoped<IQrRepository, QrRepositoryEF>();

        // services injection
        services.AddScoped<IQrService, QRService>();

        return services;
    }

    public static IServiceCollection AddMongoDB(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMongoDatabase>(a =>
        {
            // Congiguracion de entidades
            QrConfiguration.Configure();

            // Congiguracion de coneccion con MongoDB
            MongoConfiguration mongoDBSetting = new MongoConfiguration();
            configuration.Bind("MongoDBSettings", mongoDBSetting);
            var mongoClient = new MongoClient(mongoDBSetting.ConnectionString);
            return mongoClient.GetDatabase(mongoDBSetting.DatabaseName);
        });

        return services;
    }
}