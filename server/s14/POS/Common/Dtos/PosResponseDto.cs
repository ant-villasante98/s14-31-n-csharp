using S14.POS.Common.Utilities.Enums;

namespace S14.POS.Common.Dtos;

public class PosResponseDto
{
    // public Order Order { get; set; }

    public PosState Status { get; set; }

    public DateTime Date { get; set; }
}
