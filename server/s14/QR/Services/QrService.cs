using S14.QR.Commmon.Utilities;
using S14.QR.Domain;

namespace S14.QR.Service;

public class QRService : IQrService
{
    private readonly IQrRepository _repository;

    public QRService(IQrRepository repository)
    {
        _repository = repository;
    }

    // Primera Obcion
    public async Task<Qr> GenerateQr(int orderId)
    {
        string qrString = QrStringGenerator.GenerateValue();

        Qr qrModel = Qr.Create(qrString, orderId, "Hola");
        return await _repository.AddAsync(qrModel);
    }

    public async Task<bool> CheckQr(int orderId, string qrValue)
    {
        Qr? qrModel = await _repository.FindByOrderAsync(orderId);

        return qrModel is not null;
    }

    // Segunda Opcion
    public async Task<Qr> CreateQr(int orderId)
    {
        // Segunda opcion
        OrderData orderData = new OrderData() { Id = orderId };
        string qrString = QrStringGenerator.GenerateQrString(orderData);
        string qrSvg = QrStringGenerator.GenerateSvg(qrString);
        Qr qrModel = Qr.Create(qrString, orderId, qrSvg);
        return await _repository.AddAsync(qrModel);
    }

    public Task<int> CheckOrderByQr(string qrValue)
    {
        OrderData? orderData = QrStringGenerator.GetValue<OrderData>(qrValue);

        return Task.Run(() => orderData.Id);
    }

    public async Task<string> GetSvgByOrderId(int orderId)
    {
        Qr? qrModel = await _repository.FindByOrderAsync(orderId);

        if (qrModel is null)
        {
            return string.Empty;
        }

        return qrModel.SvgValue;
    }
}