using AutoMapper;
using SignalR.DtoLayer.Dto.AboutDto;
using SignR.Entitylayer.Entites;

namespace SignalRApı.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();

        }
    }
}
