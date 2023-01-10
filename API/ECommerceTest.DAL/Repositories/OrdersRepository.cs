using ECommerceTest.DAL.DTOs;
using ECommerceTest.DAL.IRepositories;

namespace ECommerceTest.DAL.Repositories;

public class OrdersRepository : Repository, IOrdersRepository
{
	public OrdersRepository()
		: base("db", "orders")
	{ }

	public async Task<Guid?> Create(OrderCreateDTO orderCreateDTO)
	{
		var orderDTO = new OrderDTO(
			Guid.NewGuid(),
			orderCreateDTO.payment,
			orderCreateDTO.delivery,
			orderCreateDTO.products
		);
		var result = await Container.CreateItemAsync(orderDTO);
		return result.Resource.id;
	}
}
