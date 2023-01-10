using AutoMapper;
using ECommerceTest.DAL.Repositories;
using ECommerceTest.ThirdParty.Payment;
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
	public class Payment
	{
		private readonly IMapper _mapper;
		private readonly IPaymentService _paymentService;

		public Payment(IMapper mapper, IPaymentService paymentService)
		{
			this._paymentService = paymentService;
			_mapper = mapper;
		}

		/*[FunctionName("PaymentCreateInvoice")]
		public async Task<IActionResult> CreateInvoice(
			[HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "payment/invoice/create")] HttpRequest req,
			ILogger log)
		{
			var websiteUrl = Environment.GetEnvironmentVariable("SITE_BASE_URL");
			if (websiteUrl == null)
				return new InternalServerErrorResult();

			string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
			var order = JsonConvert.DeserializeObject<OrderModel>(requestBody);

			var callbackUri = new Uri(new Uri(websiteUrl), "api/PaymentTest");
			var invoiceDTO = await _paymentService.CreateInvoiceAsync(callbackUri, callbackUri);
			var invoice = _mapper.Map<InvoiceResultModel>(invoiceDTO);

			return new OkObjectResult(invoice);
		}*/

		[FunctionName("PaymentTest")]
		public async Task<IActionResult> PaymentTest(
			[HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "payment/set-status")] HttpRequest req,
			ILogger log)
		{
			string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

			var logRepo = new LogTest();
			
			logRepo.Log(JsonConvert.SerializeObject(new
			{
				Query = req.Query,
				RequestBody = requestBody
			}));
			
			return new OkResult();
		}
	}
}
