using AutoMapper;
using S14.Payments.Common.Dtos;
using S14.Payments.Common.Utilities;
using S14.Payments.Domain;

namespace S14.Payments.Common.Mappers;

public class PaymentsMapperProfile : Profile
{
    public PaymentsMapperProfile()
    {
        // CreateMap<Payment, PaymentResponse>()
        //     .ForMember(d => d.OrderId, opt => opt.MapFrom(o => o.Order.Id));

        CreateMap<Payment, PaymentResponse>();
        CreateMap<PaymentError, PaymentErrorResponse>();
    }
}
