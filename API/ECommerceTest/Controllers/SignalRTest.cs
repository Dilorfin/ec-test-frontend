using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using System;
using System.Threading.Tasks;

namespace ECommerceTest.Controllers
{
	public static class SignalRTest
	{
		[FunctionName("negotiate")]
		public static SignalRConnectionInfo Negotiate(
			[HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequest req,
			[SignalRConnectionInfo(HubName = "serverless")] SignalRConnectionInfo connectionInfo)
		{
			return connectionInfo;
		}

		// static web apps supports only httpTriggers
		//[FunctionName("broadcast")]
		//public static async Task Broadcast([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer,
		//[SignalR(HubName = "serverless")] IAsyncCollector<SignalRMessage> signalRMessages)
		//{
		//	await signalRMessages.AddAsync(
		//		new SignalRMessage
		//		{
		//			Target = "testEvent",
		//			Arguments = new object[] { $"Time: {DateTime.Now.ToLongTimeString()}" }
		//		});
		//}
	}
}
