using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Services;
using SignalR.DtoLayer.Dto.ProductDto;
using SignalR.DtoLayer.Dto.SocialMediaDto;
using SignR.Entitylayer.Entites;

namespace SignalRApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaServices _socialMediaServices;
        private readonly IMapper mapper;

        public SocialMediaController(ISocialMediaServices productServices, IMapper mapper)
        {
            _socialMediaServices = productServices;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSocialList()
        {
            var list = mapper.Map<List<ResultProductDto>>(_socialMediaServices.GetAll());
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetSocial(int id)
        {
            var find = _socialMediaServices.GetById(id);
            return Ok(find);
        }


        [HttpPost]
        public IActionResult AddProduct(ResultSocialMediDto resultSocialMediDto)
        {
            _socialMediaServices.Add(new SocialMedia()
            {
               Icon = resultSocialMediDto.Icon,
               Title = resultSocialMediDto.Title,
               Url = resultSocialMediDto.Url,
            });

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateSocial(UpdateSocialMediaDto updateSocialMediaDto)
        {
            _socialMediaServices.Update(new SocialMedia()
            {
                SocialMediaID = updateSocialMediaDto.SocialMediaID,
                Title = updateSocialMediaDto.Title,
                Url= updateSocialMediaDto.Url,
                Icon = updateSocialMediaDto.Icon

            });

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocial(int id)
        {
            var find = _socialMediaServices.GetById(id);
            _socialMediaServices.Remove(find);
            return Ok();
        }
    }
}
