using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Services;
using SignalR.DtoLayer.Dto.CategoryDto;
using SignR.Entitylayer.Entites;

namespace SignalRApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryServices categoryServices, IMapper mapper)
        {
            _categoryServices = categoryServices;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListCategory()
        {
            var list = _mapper.Map<List<ResultCategoryDto>>(_categoryServices.GetAll());
            return Ok(list);
        }


        [HttpPost]
        public IActionResult AddCategory(CreateCategoryDto createCategoryDto)
        {
            _categoryServices.Add(new Category()
            {
                CategoryName = createCategoryDto.CategoryName,
                Status = createCategoryDto.Status,
            });

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            _categoryServices.Update(new Category()
            {
                CategoryID = updateCategoryDto.CategoryID,
                 CategoryName= updateCategoryDto.CategoryName,
                Status = updateCategoryDto.Status,
            });

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var find = _categoryServices.GetById(id);
            _categoryServices.Remove(find);

            return Ok("Silme işlemi başarılı.");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var find = _categoryServices.GetById(id);
            return Ok(find);
        }
    }
}
