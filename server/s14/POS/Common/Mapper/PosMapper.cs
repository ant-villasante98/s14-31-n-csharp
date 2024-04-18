using AutoMapper;
using S14.POS.Common.Dtos;
using S14.POS.Domain;

namespace S14.POS.Common.Mapper;

public class PosMapper : Profile
{
    public PosMapper()
    {
        CreateMap<PosRequestDto, Pos>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date));

        CreateMap<PosResponseDto, Pos>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
    }
}