using ECommerceTest.DAL.DTOs;

namespace ECommerceTest.ThirdParty.Delivery;

public interface IDeliveryService
{
	public Task<bool> ValidateOrderDelivery(OrderDeliveryDTO deliveryDTO);
}
