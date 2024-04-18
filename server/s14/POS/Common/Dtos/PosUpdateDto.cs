using S14.POS.Common.Utilities.Enums;

namespace S14.POS.Common.Dtos;

public class PosUpdateDto
{
    public int OrderId { get; set; }

    public DateTime Date { get; set; }

    public PosState Status { get; set; }
}
