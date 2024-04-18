using S14.POS.Common.Utilities.Enums;

namespace S14.POS.Domain;

public class Pos
{
    public int Id { get; set; }

    // public Order Order { get; set; }
    
    public int OrderId { get; set; }

    public PosState Status { get; set; }

    public DateTime Date { get; set; }
}
