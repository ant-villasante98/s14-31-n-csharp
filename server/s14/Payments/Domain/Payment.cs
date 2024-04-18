using S14.Orders.Domain;
using S14.Payments.Common.Utilities;

namespace S14.Payments.Domain;

public class Payment
{
    public Guid Id { get; set; }

    // public Order Order { get; set; }
    public int OrderId { get; set; }

    public DateTime PaymentDate { get; set; }

    // public string Consecutive { get; set; }

    public ICollection<PaymentError> Errors { get; set; }

    // Bandera para saber si el pago se realizo correctamente
    public bool IsValid { get; set; } = true;
}