using ECommerceTest.DAL.DTOs;
using ECommerceTest.DAL.IRepositories;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ECommerceTest.DAL.Repositories;

public class OrdersRepository : Repository, IOrdersRepository
{
	private readonly IMongoCollection<OrderDTO> _collection;

	public OrdersRepository()
	{
		_collection = Database.GetCollection<OrderDTO>("orders");
	}

	public async Task<string> Create(OrderCreateDTO orderCreateDTO)
	{
		var orderDTO = new OrderDTO()
		{
			Id = ObjectId.GenerateNewId(),
			Payment = orderCreateDTO.payment,
			Delivery = orderCreateDTO.delivery,
			Products = orderCreateDTO.products
		};
		await _collection.InsertOneAsync(orderDTO);
		return orderDTO.Id.ToString();
	}
}
