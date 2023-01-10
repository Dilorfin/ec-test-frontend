using ECommerceTest.DAL.DTOs;
using ECommerceTest.DAL.IRepositories;
using Microsoft.Azure.Cosmos.Linq;

namespace ECommerceTest.DAL.Repositories;

public class ProductsRepository : Repository, IProductsRepository
{
	public ProductsRepository()
		: base("db", "products")
	{ }

	public async Task<ProductDTO> GetProductAsync(string id)
	{
		string query = $@"SELECT * FROM products WHERE products.id = '{id}'";
		var iterator = Container.GetItemQueryIterator<ProductDTO>(query);
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
		var iterator = Container.GetItemLinqQueryable<ProductDTO>()
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
