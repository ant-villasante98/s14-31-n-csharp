using AutoMapper;
using S14.MenuSystem.Common.Dtos;
using S14.MenuSystem.Domain;

namespace S14.MenuSystem.Common.Mappers
{
    public class MenuSystemProfile : Profile
    {
        public MenuSystemProfile()
        {
            CreateMap<Mall, MallResponse>();

            CreateMap<Shop, ShopResponse>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(
                    src => src.Menu.Select(x => x.Category.Name).Distinct()
                    .ToArray()));

            CreateMap<MenuItem, MenuItemResponse>()
                .ForMember(
                    dest => dest.Category,
                    opt => opt.MapFrom(src => src.Category.Name ?? null));
        }
    }
}