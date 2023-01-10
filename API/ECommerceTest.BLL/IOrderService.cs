using ECommerceTest.DAL.DTOs;

namespace ECommerceTest.BLL;

public interface IOrderService
{
	Task<bool> ValidateOrder(OrderCreateDTO order);
	Task<OrderCreateResultDTO> CreateOrder(OrderCreateDTO order);
}
