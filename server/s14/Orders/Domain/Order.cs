using S14.Orders.Common.Dtos;
using S14.Orders.Domain.Enums;

namespace S14.Orders.Domain
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime CreationDate { get; set; }

        public OrderStatus Status { get; set; }

        public ICollection<DetailOrder> Details { get; set; } = new List<DetailOrder>();

        public ICollection<HistoryState> HistoryState { get; set; } = new List<HistoryState>();
    }
}