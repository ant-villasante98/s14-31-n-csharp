namespace S14.QR.Infrastructure.MongoDB.PersistanceMongo;
public class MongoConfiguration
{
    // docker run --rm -it -p27018:27017 --name QrDB -e MONGO_INITDB_ROOT_USERNAME=mongo -e MONGO_INITDB_ROOT_PASSWORD=password mongo
    public string ConnectionString { get; set; } = string.Empty;

    public string DatabaseName { get; set; } = string.Empty;
}