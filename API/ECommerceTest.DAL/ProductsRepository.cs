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

	public async Task<ProductDTO> GetProductAsync(string id)
	{
		string query = $@"SELECT * FROM products WHERE products.id = '{id}'";
		var iterator = _container.GetItemQueryIterator<ProductDTO>(query);
		var matches = new List<ProductDTO>();
		while (iterator.HasMoreResults)
		{
			var next = await iterator.ReadNextAsync();
			matches.AddRange(next);
		}
		return matches.SingleOrDefault();
	}

	public async Task<IEnumerable<ProductDTO>> GetProductsAsync(uint offset, uint count)
	{
		var iterator = _container.GetItemLinqQueryable<ProductDTO>()
		   .Skip((int)offset)
		   .Take((int)count)
		   .ToFeedIterator();

		List<ProductDTO> list = new List<ProductDTO>();
		while (iterator.HasMoreResults)
		{
			var next = await iterator.ReadNextAsync();
			list.AddRange(next);
		}

		return list;
	}
}
