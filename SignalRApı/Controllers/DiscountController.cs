using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Services;
using SignalR.DtoLayer.Dto.CategoryDto;
using SignalR.DtoLayer.Dto.DiscountDto;
using SignR.Entitylayer.Entites;

namespace SignalRApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountServices _discountServices;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountServices discountServices, IMapper mapper)
        {
            _discountServices = discountServices;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var list = _mapper.Map<List<ResultCategoryDto>>(_discountServices.GetAll());
            return Ok(list);
        }


        [HttpPost]
        public IActionResult AddDiscount(CreateDiscountDto createDiscountDto)
        {
            _discountServices.Add(new Discount()
            {
               Amount =createDiscountDto.Amount,
               Description = createDiscountDto.Description,
               ImageUrl = createDiscountDto.ImageUrl,
               Title= createDiscountDto.Title
            });

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
           _discountServices.Update(new Discount()
            {
               DiscountID=updateDiscountDto.DiscountID,
               Amount = updateDiscountDto.Amount,
               Description = updateDiscountDto.Description,
               ImageUrl = updateDiscountDto.ImageUrl,
               Title = updateDiscountDto.Title
           });

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var find = _discountServices.GetById(id);
            _discountServices.Remove(find);

            return Ok("Silme işlemi başarılı.");
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var find = _discountServices.GetById(id);
            return Ok(find);
        }
    }
}
