using S14.Payments.Common.Utilities;
using S14.Payments.Domain.Enums;

namespace S14.Payments.Common.Dtos;

public class PaymentResponse
{
    public int OrderId { get; set; }

    public DateTime PaymentDate { get; set; }

    public ICollection<PaymentError> Errors { get; set; }

    // Bandera para saber si el pago se realizo correctamente
    public bool IsValid { get; set; }

    // public bool IsValid { get => this.Errors.Count > 0; set; }
}
