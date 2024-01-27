using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Services;
using SignalR.DtoLayer.Dto.BookingDto;
using SignalR.DtoLayer.Dto.FeatureDto;
using SignR.Entitylayer.Entites;

namespace SignalRApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeaturesServices featuresServices;
        private readonly IMapper mapper;

        public FeatureController(IFeaturesServices featuresServices, IMapper mapper)
        {
            this.featuresServices = featuresServices;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var list = mapper.Map<List<ResultFeatureDto>>(featuresServices.GetAll());
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult getFeatureDetails(int id)
        {
            var featureDetails = featuresServices.GetById(id);
            return Ok(featureDetails);
        }


        [HttpPost]
        public IActionResult AddFeature(CreateFeatureDto createFeatureDto)
        {

            featuresServices.Add(new Feature()
            {
                Title1 = createFeatureDto.Title1,
                Title2 = createFeatureDto.Title2,
                Title3 = createFeatureDto.Title3,
                Description3 = createFeatureDto.Description3,
                Description2 = createFeatureDto.Description2,
                Description1 = createFeatureDto.Description1,
            });
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            featuresServices.Update(new Feature()
            {
                FeatureID=updateFeatureDto.FeatureID,
                Title1 = updateFeatureDto.Title1,
                Title2 = updateFeatureDto.Title2,
                Title3 = updateFeatureDto.Title3,
                Description3 = updateFeatureDto.Description3,
                Description2 = updateFeatureDto.Description2,
                Description1 = updateFeatureDto.Description1,
            });

            
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var find = featuresServices.GetById(id);
            featuresServices.Remove(find);

            return Ok();
        }
    }
}
