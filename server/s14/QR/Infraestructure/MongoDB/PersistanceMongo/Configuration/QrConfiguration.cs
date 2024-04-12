using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using S14.QR.Domain;

namespace S14.QR.Infrastructure.MongoDB.Configuration;

public static class QrConfiguration
{
    public static void Configure()
    {
        BsonClassMap.RegisterClassMap<Qr>(cm =>
        {
            cm.AutoMap();
            cm.SetIgnoreExtraElements(false);

            cm.MapIdMember(c => c.Id).SetSerializer(new GuidSerializer(GuidRepresentation.Standard));
            cm.MapMember(c => c.CodeValue);
            cm.MapMember(c => c.GenerationDate);
            cm.MapMember(c => c.OrderId);
            cm.MapMember(c => c.SvgValue);
        });
    }
}