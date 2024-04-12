using MongoDB.Bson;
using MongoDB.Driver;
using S14.QR.Domain;

namespace S14.QR.Infrastructure.MongoDB.Repositories;

public class QrRepositoryMongoDB : IQrRepository
{
    private readonly string _collectionName = "Qrs";
    private readonly IMongoCollection<Qr> _qrCollection;
    private readonly FilterDefinitionBuilder<Qr> _filterBuilder = Builders<Qr>.Filter;

    public QrRepositoryMongoDB(IMongoDatabase mongoDatabase)
    {
        _qrCollection = mongoDatabase?.GetCollection<Qr>(_collectionName) ?? throw new ArgumentNullException("No se encontro la base de datos");
    }

    public async Task<Qr> AddAsync(Qr model)
    {
        await _qrCollection.InsertOneAsync(model);
        return model;
    }

    public async Task DeleteAsync(Guid id)
    {
        var filter = _filterBuilder.Eq("_id", id.ToString());
        await _qrCollection.DeleteOneAsync(filter);
    }

    public async Task DeleteAsync(Qr model)
    {
        if (model is Qr)
        {
            await this.DeleteAsync(model.Id);
        }
    }

    public async Task<List<Qr>> FindAllAsync()
    {
        return await _qrCollection.Find(_ => true).ToListAsync();
    }

    public async Task<Qr?> FindByIdAsync(Guid id)
    {
        var filter = _filterBuilder.Eq("_id", id.ToString());
        return await _qrCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<Qr?> FindByOrderAsync(int orderId)
    {
        var filter = _filterBuilder.Eq(x => x.OrderId, orderId);
        return await _qrCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<Qr> UpdateAsync(Qr model)
    {
        if (model is null)
        {
            throw new NullReferenceException();
        }

        var filter = _filterBuilder.Eq("_id", model.Id.ToString());
        await _qrCollection.ReplaceOneAsync(filter, model);
        return model;
    }
}