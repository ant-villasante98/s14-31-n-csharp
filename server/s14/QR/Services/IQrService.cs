using S14.QR.Domain;

namespace S14.QR.Service;

public interface IQrService
{
    Task<Qr> GenerateQr(int orderId);

    Task<bool> CheckQr(int orderId, string qrValue);

    public Task<Qr> CreateQr(int orderId);

    public Task<int> CheckOrderByQr(string qrValue);

    public Task<string> GetSvgByOrderId(int orderId);
}