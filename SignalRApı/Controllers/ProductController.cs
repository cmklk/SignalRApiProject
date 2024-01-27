using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Services;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.Dto.ProductDto;
using SignalR.DtoLayer.Dto.TestimonialDto;
using SignR.Entitylayer.Entites;

namespace SignalRApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;
        private readonly IMapper mapper;

        public ProductController(IProductServices productServices, IMapper mapper)
        {
            _productServices = productServices;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProductList()
        {
            var list = mapper.Map<List<ResultProductDto>>(_productServices.GetAll());
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var find = _productServices.GetById(id);
            return Ok(find);
        }


        [HttpPost]
        public IActionResult AddProduct(CreateProductDto createProduct)
        {
            _productServices.Add(new Product()
            {
               Description = createProduct.Description,
               ImageUrl = createProduct.ImageUrl,
               Price = createProduct.Price,
               ProductName = createProduct.ProductName,
               CategoryID = createProduct.CategoryID,
            });

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productServices.Update(new Product()
            {
                ProductID = updateProductDto.ProductID,
                ProductName = updateProductDto.ProductName,
                Price= updateProductDto.Price,
                Description = updateProductDto.Description,
                CategoryID = updateProductDto.CategoryID,
                ProductStatus = updateProductDto.ProductStatus,
                ImageUrl= updateProductDto.ImageUrl,
             
            });

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var find = _productServices.GetById(id);
            _productServices.Remove(find);
            return Ok();
        }

        [HttpGet("ProductGetListWithCategory")]
        public IActionResult ProductGetListWithCategory()
        {
            var context = new SignalRContext();
            var list = context.Products.Include(x => x.Category).Select(y => new ProductListWithCategoryDto()
            {
                ProductID=y.ProductID,
                ProductName = y.ProductName,
                ProductStatus = y.ProductStatus,
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
               CategoryName = y.Category.CategoryName            });
            return Ok(list.ToList());
        }
    }
}
