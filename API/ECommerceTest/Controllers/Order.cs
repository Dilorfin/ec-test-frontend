using AutoMapper;
using ECommerceTest.BLL;
using ECommerceTest.DAL.DTOs;
using ECommerceTest.Models.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace ECommerceTest.Controllers
{
	public class Order
	{
		private readonly IMapper _mapper;
		private readonly IOrderService _orderService;

		public Order(IMapper mapper, IOrderService orderService)
		{
			_mapper = mapper;
			_orderService = orderService;
		}

		[FunctionName("OrderPlace")]
		public async Task<IActionResult> OrderPlace(
			[HttpTrigger(AuthorizationLevel.Function, "post", Route = "order/place")] HttpRequest req,
			ILogger log)
		{
			string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
			OrderCreateModel order = JsonConvert.DeserializeObject<OrderCreateModel>(requestBody);

			OrderCreateDTO orderDTO = _mapper.Map<OrderCreateDTO>(order);
			OrderCreateResultDTO result = await _orderService.CreateOrder(orderDTO);

			if (string.IsNullOrEmpty(result.orderId))
			{
				return new BadRequestResult();
			}

			return new OkObjectResult(result);
		}
	}
}
