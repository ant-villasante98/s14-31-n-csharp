using S14.Orders.Domain;
using S14.Orders.Domain.Enums;

namespace S14.Orders.Common.Dtos
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public OrderStatus Status { get; set; }

        public List<DetailOrderDTO> Details { get; set; }

        public List<HistoryStateDTO> HistoryState { get; set; }

        public string? CodeQr { get; set; }
    }
}