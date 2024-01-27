using AutoMapper;
using SignalR.DtoLayer.Dto.AboutDto;
using SignalR.DtoLayer.Dto.FeatureDto;
using SignR.Entitylayer.Entites;

namespace SignalRApı.Mapping
{
    public class FeatureMapping:Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
        }
    }
}
