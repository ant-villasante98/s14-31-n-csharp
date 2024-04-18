using S14.Orders.Domain;
using S14.Payments.Common.Dtos;

namespace S14.Payments.Services;

public interface IPaymentService
{
    Task<PaymentResponse> CreatePayment(Order? order);
}

// Al momento de crear el pago, deberia llamar a un metodo similar al siguiente perteneciente al servicio 
// de orders que reciba una orden y compruebe que siga siendo valida, validando si los productos contenidos
// en ella tienen stock disponible, para definir si es posible concretar el pago o no
// Task<bool> ValidateOrder(Order order);
