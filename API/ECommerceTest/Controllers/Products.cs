using AutoMapper;
using ECommerceTest.DAL;
using ECommerceTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceTest.Controllers
{
	public class Products
	{
		private readonly IMapper _mapper;
		private readonly IProductsRepository _productsRepository;

		public Products(IMapper mapper, IProductsRepository productsRepository)
		{
			_mapper = mapper;
			_productsRepository = productsRepository;
		}

		[FunctionName("Products")]
		public async Task<IActionResult> GetProductsList(
			[HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "products/list")] HttpRequest req,
			ILogger log)
		{
			string offset = req.Query["offset"];
			string count = req.Query["count"];

			/*string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
			dynamic data = JsonConvert.DeserializeObject(requestBody);
			name = name ?? data?.name;*/

			var result = _mapper.Map<IEnumerable<ProductListModel>>(await _productsRepository.GetProductsAsync(0, 25));
			return new OkObjectResult(result);
		}
	}
}
