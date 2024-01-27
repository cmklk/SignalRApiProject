using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Services;
using SignalR.DtoLayer.Dto.ContactDto;
using SignalR.DtoLayer.Dto.TestimonialDto;
using SignR.Entitylayer.Entites;

namespace SignalRApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialServices _testimonialServices;
        private readonly IMapper mapper;

        public TestimonialController(ITestimonialServices testimonialServices, IMapper mapper)
        {
            _testimonialServices = testimonialServices;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GeTestimonialList()
        {
            var list = mapper.Map<List<ResultTestimonialDto>>(_testimonialServices.GetAll());
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var find = _testimonialServices.GetById(id);
            return Ok(find);
        }


        [HttpPost]
        public IActionResult AddTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialServices.Add(new Testimonial()
            {
                Name= createTestimonialDto.Name,
                Comment = createTestimonialDto.Comment,
                ImageUrl =createTestimonialDto.ImageUrl,
                Title = createTestimonialDto.Title,
                Status = true
            });

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
           _testimonialServices.Update(new Testimonial()
            {
                TestimonialID=updateTestimonialDto.TestimonialID,
                Name = updateTestimonialDto.Name,
                Comment = updateTestimonialDto.Comment,
                ImageUrl = updateTestimonialDto.ImageUrl,
                Title = updateTestimonialDto.Title,
                Status = true
            });

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var find = _testimonialServices.GetById(id);
           _testimonialServices.Remove(find);
            return Ok();
        }
    }
}
