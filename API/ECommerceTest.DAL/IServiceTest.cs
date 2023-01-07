namespace ECommerceTest.DAL;

public interface IServiceTest
{
	string Test(string name);
}

public class ServiceTest : IServiceTest
{
	public string Test(string name)
	{
		return string.IsNullOrEmpty(name)
			? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
			: $"Hello, {name}. This HTTP triggered function executed successfully.";
	}
}
