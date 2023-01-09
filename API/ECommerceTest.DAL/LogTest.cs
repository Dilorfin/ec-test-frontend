using Microsoft.Azure.Cosmos;

namespace ECommerceTest.DAL;

public class LogTest : Repository
{
	public LogTest()
		: base("db", "my-test-logs")
	{ }

	public async void Log(string str)
	{
		ItemResponse<dynamic> response = await Container.CreateItemAsync<dynamic>(new
		{
			id = Guid.NewGuid(),
			data = str
		});
	}
}
