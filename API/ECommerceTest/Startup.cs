using ECommerceTest.ThirdParty.Payment;
using ECommerceTest.ThirdParty.Payment.Monobank;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(ECommerceTest.Startup))]

namespace ECommerceTest
{
	public class Startup : FunctionsStartup
	{
		public override void Configure(IFunctionsHostBuilder builder)
		{
			/*builder.Services.AddSingleton<IMyService>((s) => {
				return new MyService();
			});*/
			
			builder.Services.AddSingleton<IPaymentService, MonobankPaymentService>();
		}
	}
}
