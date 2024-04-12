using AutoMapper;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using S14.Orders.Common.Dtos;
using S14.Orders.Domain;
using S14.Orders.Domain.Enums;

namespace S14.Orders.Common.Mappers
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<CreateOrderDTO, Order>()
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => OrderStatus.Created))
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Items.Select(item => new DetailOrder
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                })));
            
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Details.Select(details => new DetailOrderDTO
                {
                    ProductId = details.ProductId,
                    Quantity = details.Quantity,
                    Price = details.Price
                })))
                .ForMember(dest => dest.HistoryState, opt => opt.MapFrom(src => src.HistoryState.Select(history => new HistoryStateDTO
                {
                    Status = history.Status,
                    Date = history.Date
                })));
        }
    }
}