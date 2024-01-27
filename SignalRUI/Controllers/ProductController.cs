using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalRUI.ViewModels.Category;
using SignalRUI.ViewModels.Product;
using System.Text;

namespace SignalRUI.Controllers
{
	public class ProductController : Controller
	{
		private readonly IHttpClientFactory httpClientFactory;

		public ProductController(IHttpClientFactory httpClientFactory)
		{
			this.httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7234/api/Product/ProductGetListWithCategory");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> AddProduct()
		{
			var client = httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7234/api/Category");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
			List<SelectListItem> getCategoryValues = (from x in values
													  select new SelectListItem
													  {
														  Text = x.CategoryName,
														  Value = x.CategoryID.ToString()
													  }).ToList();

			ViewBag.values = getCategoryValues;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddProduct(CreateProductDto createProductDto)
		{
			createProductDto.ProductStatus = true;
			var client = httpClientFactory.CreateClient();
			var data = JsonConvert.SerializeObject(createProductDto);
			StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
			var responsemessage = await client.PostAsync("https://localhost:7234/api/Product",content);
			if(responsemessage.IsSuccessStatusCode) {

				return RedirectToAction("Index");
			}

			return View();
		}


		public async Task<IActionResult> DeleteProduct(int id)
		{
			var client = httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7234/api/Product/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}



		[HttpGet]
		public async Task<IActionResult> UpdateProduct(int id)
		{
			var client = httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7234/api/Category");
			var jsonData =await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

			List<SelectListItem> values1 = (from x in values
										   select new SelectListItem
										   {
											   Text = x.CategoryName,
											   Value = x.CategoryID.ToString()
										   }).ToList();
			ViewBag.values = values1;


			var client1 = httpClientFactory.CreateClient();
			var responseMessage1 = await client1.GetAsync($"https://localhost:7234/api/Product/{id}");
		    if(responseMessage1.IsSuccessStatusCode)
			{
				var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
				var values2 = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData1);
				return View(values2);
			}
			return View();
			
		
		}

		[HttpPost]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
		{
			
			var client = httpClientFactory.CreateClient();
			var data = JsonConvert.SerializeObject(updateProductDto);
			StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
			var responsemessage = await client.PutAsync("https://localhost:7234/api/Product", content);
			if (responsemessage.IsSuccessStatusCode)
			{

				return RedirectToAction("Index");
			}

			return View();
		}


	}
}
