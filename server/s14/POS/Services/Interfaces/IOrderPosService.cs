using S14.Orders.Domain.Enums;

namespace S14.POS.Services;

public interface IOrderPosService
{
    public Task ChangeOrderState(int orderId, OrderStatus status);

    public Task<int> ValidateQr(string qrValue);
}
