namespace S14.QR.Domain;
public class Qr
{
    public Guid Id { get; init; }

    public string CodeValue { get; set; } = string.Empty;

    public string SvgValue { get; set; } = string.Empty;

    public DateTime GenerationDate { get; set; }

    public int OrderId { get; set; }

    public static Qr Create(string codeValue, int orderId, string svgValue)
    {
        return new Qr()
        {
            Id = Guid.NewGuid(),
            CodeValue = codeValue,
            SvgValue = svgValue,
            GenerationDate = DateTime.UtcNow,
            OrderId = orderId
        };
    }
}