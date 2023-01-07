using ECommerceTest.DAL.DTOs;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace ECommerceTest.DAL;

public class ProductsRepository : IProductsRepository
{
	private readonly Container _container;

	public ProductsRepository()
	{
		//string connectionString = ConfigurationManager.ConnectionStrings["DB_CONNECTION_STRING"].ConnectionString;
		string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
		string database = "db";
		string container = "products";

		_container = new CosmosClient(connectionString)
			.GetDatabase(database)
			.GetContainer(container);
	}

	public async Task<IEnumerable<ProductListDTO>> GetProductsAsync(uint offset, uint count)
	{
		var iterator = _container.GetItemLinqQueryable<ProductListDTO>()
		   .Skip((int)offset)
		   .Take((int)count)
		   .ToFeedIterator();

		List<ProductListDTO> list = new List<ProductListDTO>();
		while (iterator.HasMoreResults)
		{
			var next = await iterator.ReadNextAsync();
			list.AddRange(next);
		}

		return list;
	}
}
