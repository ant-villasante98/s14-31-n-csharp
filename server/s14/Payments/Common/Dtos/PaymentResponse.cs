namespace S14.Payments.Common.Dtos;

public class PaymentResponse
{
    public int OrderId { get; set; }

    public DateTime PaymentDate { get; set; }

    public ICollection<PaymentErrorResponse> Errors { get; set; }

    // Bandera para saber si el pago se realizo correctamente
    public bool IsValid { get; set; }
}
