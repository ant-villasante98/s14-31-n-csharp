namespace S14.QR.Domain;
public interface IQrRepository
{
    Task<Qr?> FindByIdAsync(Guid id);

    Task<Qr> AddAsync(Qr model);

    Task<Qr?> FindByOrderAsync(int orderId);

    Task<List<Qr>> FindAllAsync();

    Task<Qr> UpdateAsync(Qr model);

    Task DeleteAsync(Guid id);

    Task DeleteAsync(Qr model);
}