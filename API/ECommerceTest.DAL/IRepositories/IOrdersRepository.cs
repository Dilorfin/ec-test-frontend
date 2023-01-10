using ECommerceTest.DAL.DTOs;

namespace ECommerceTest.DAL.IRepositories;

public interface IOrdersRepository
{
	Task<Guid?> Create(OrderCreateDTO orderCreateDTO);
}
