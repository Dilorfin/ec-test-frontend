using ECommerceTest.ThirdParty.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace ECommerceTest.Controllers
{
	public class Payment
	{
		private readonly IPaymentService _paymentService;

		public Payment(IPaymentService paymentService)
		{
			this._paymentService = paymentService;
		}

		[FunctionName("PaymentCreateInvoice")]
		public async Task<IActionResult> CreateInvoice(
			[HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "payment/invoice/create")] HttpRequest req,
			ILogger log)
		{
			var websiteUrl = Environment.GetEnvironmentVariable("SITE_BASE_URL");
			if (websiteUrl == null)
				return new InternalServerErrorResult();

			var callbackUri = new Uri(new Uri(websiteUrl), "api/Test");
			var invoice = await _paymentService.CreateInvoiceAsync(callbackUri, callbackUri);
			
			return new OkObjectResult(new
			{
				Test = callbackUri.ToString(),
				Invoice = invoice
			});
			
			//log.LogInformation(callbackUri.ToString());
			//return new OkResult();
		}

		[FunctionName("Test")]
		public async Task<IActionResult> Test(
			[HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "Test")] HttpRequest req,
			ILogger log)
		{
			//log.LogInformation($"data: {req.}");

			/*var invoice = await _paymentService.CreateInvoiceAsync();
			if (invoice == null)
				return new InternalServerErrorResult();
			return new OkObjectResult(invoice);*/
			//var callbackUri = new Uri(new Uri($"{req.Scheme}://{req.Host.Value}"), "/Test");
			
			return new OkResult();
		}
	}
}
