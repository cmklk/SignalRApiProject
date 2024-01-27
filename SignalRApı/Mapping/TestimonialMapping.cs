using AutoMapper;
using SignalR.DtoLayer.Dto.AboutDto;
using SignalR.DtoLayer.Dto.TestimonialDto;
using SignR.Entitylayer.Entites;

namespace SignalRApı.Mapping
{
    public class TestimonialMapping:Profile
    {
        public TestimonialMapping()
        {
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
        }
    }
}
