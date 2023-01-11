using AutoMapper;
using ECommerceTest.Common;
using ECommerceTest.DAL.IRepositories;
using ECommerceTest.Models.Product;
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

		[FunctionName("Test")]
		public async Task<IActionResult> Test(
			[HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "test")] HttpRequest req,
			ILogger log)
		{
			return new OkObjectResult(AzureAuthUtils.GetAzureUserFromRequest(req));
		}

		[FunctionName("GetProductDetails")]
		public async Task<IActionResult> GetProductDetails(
			[HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "product/{id}")] HttpRequest req,
			string id)
		{
			var productDTO = await _productsRepository.GetProductAsync(id);
			var product = _mapper.Map<ProductDetailedModel>(productDTO);
			return new OkObjectResult(product);
		}

		[FunctionName("GetProductsList")]
		public async Task<IActionResult> GetProductsList(
			[HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "products/list")] HttpRequest req)
		{
			//string offset = req.Query["offset"];
			//string count = req.Query["count"];
			
			var productDTOs = await _productsRepository.GetProductsAsync(0, 25);
			var products = _mapper.Map<IEnumerable<ProductListModel>>(productDTOs);
			return new OkObjectResult(products);
		}
	}
}
