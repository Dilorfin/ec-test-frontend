using ECommerceTest.DAL.DTOs;

namespace ECommerceTest.DAL.IRepositories;

public interface IOrdersRepository
{
	Task<string> Create(OrderCreateDTO orderCreateDTO);
}
