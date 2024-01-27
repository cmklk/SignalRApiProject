using AutoMapper;
using SignalR.DtoLayer.Dto.AboutDto;
using SignalR.DtoLayer.Dto.SocialMediaDto;
using SignR.Entitylayer.Entites;

namespace SignalRApı.Mapping
{
    public class SocialMediaMapping:Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, ResultSocialMediDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();
        }
    }
}
