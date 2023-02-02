using ECommerceTest.DAL.DTOs;
using ECommerceTest.DAL.IRepositories;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ECommerceTest.DAL.Repositories;

public class ProductsRepository : Repository, IProductsRepository
{
	private readonly IMongoCollection<ProductDTO> _collection;

	public ProductsRepository()
	{
		_collection = Database.GetCollection<ProductDTO>("products");
	}

	public async Task<ProductDTO> GetProductAsync(string id)
	{
		var filter = Builders<ProductDTO>.Filter.Eq("_id", ObjectId.Parse(id));

		var objects = await _collection.FindAsync(filter);
		var list = await objects.ToListAsync();
		if (list.Count > 1)
		{
			throw new Exception($"Collection contain more then one _id=\"{id}\"");
		}
		return list.FirstOrDefault();
	}

	public async Task<IEnumerable<ProductDTO>> GetProductsAsync(uint offset, uint count)
	{
		return _collection.AsQueryable().Skip((int)offset).Take((int)count).ToList();
	}

	public async Task<bool> DecreaseProductAmountAsync(string id)
	{
		var update = Builders<ProductDTO>.Update.Inc("amount", -1);
		var filter = Builders<ProductDTO>.Filter.Eq("_id", id);

		UpdateResult result = await _collection.UpdateOneAsync(filter, update);
		return result.ModifiedCount == 1;
	}
}
