using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Services;
using SignalR.DtoLayer.Dto.AboutDto;
using SignR.Entitylayer.Entites;

namespace SignalRApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutServices aboutServices;

        public AboutController(IAboutServices aboutServices)
        {
            this.aboutServices = aboutServices;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var aboutList = aboutServices.GetAll();
            return Ok(aboutList);
        }

        [HttpGet("{id}")]
        public IActionResult getAboutDetails(int id)
        {
            var aboutDetails = aboutServices.GetById(id);
            return Ok(aboutDetails);
        }


        [HttpPost]
        public IActionResult AddAbout(CreateAboutDto createAboutDto)
        {
            About about = new About()
            {
                Description = createAboutDto.Description,
                ImageUrl = createAboutDto.ImageUrl,
                Title = createAboutDto.Title,
            };
            aboutServices.Add(about);
            return Ok("Hakkımızda kısmı başarılı bir şekilde oluştu");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About about = new About()
            {
                AboutId = updateAboutDto.AboutId,
                Description = updateAboutDto.Description,
                ImageUrl = updateAboutDto.ImageUrl,
                Title = updateAboutDto.Title,
            };

            aboutServices.Update(about);
            return Ok("Hakkımızda kısmı başarılı bir şekilde güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var find = aboutServices.GetById(id);
            aboutServices.Remove(find);
            return Ok("Hakkımızda kısmı başarıyla silindi");
        }
    }
}
