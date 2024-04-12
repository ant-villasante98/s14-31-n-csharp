using S14.Orders.Domain;
using S14.Orders.Domain.Enums;

namespace S14.Orders.Common.Dtos
{
    public class HistoryStateDTO
    {
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
    }
}