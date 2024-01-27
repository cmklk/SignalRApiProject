using AutoMapper;
using SignalR.DtoLayer.Dto.AboutDto;
using SignalR.DtoLayer.Dto.BookingDto;
using SignR.Entitylayer.Entites;

namespace SignalRApı.Mapping
{
    public class BookingMapping:Profile
    {
        public BookingMapping()
        {
            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, ResultBookingDto>().ReverseMap();
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();
        }
    }
}
