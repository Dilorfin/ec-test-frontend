using ECommerceTest.DAL;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(ECommerceTest.Startup))]

namespace ECommerceTest
{
	public class Startup : FunctionsStartup
	{
		public override void Configure(IFunctionsHostBuilder builder)
		{
			//builder.Services.AddHttpClient();

			/*builder.Services.AddSingleton<IMyService>((s) => {
				return new MyService();
			});*/

			builder.Services.AddSingleton<IServiceTest, ServiceTest>();
		}
	}
}
