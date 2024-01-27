using AutoMapper;
using SignalR.DtoLayer.Dto.AboutDto;
using SignalR.DtoLayer.Dto.DiscountDto;
using SignR.Entitylayer.Entites;

namespace SignalRApı.Mapping
{
    public class DiscountMapping:Profile
    {
        public DiscountMapping()
        {
            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, ResultDiscountDto>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
        }
    }
}
