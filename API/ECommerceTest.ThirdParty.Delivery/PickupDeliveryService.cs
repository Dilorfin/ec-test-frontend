using ECommerceTest.DAL.DTOs;

namespace ECommerceTest.ThirdParty.Delivery;

public class PickupDeliveryService : IDeliveryService
{
	public Task<bool> ValidateOrderDelivery(OrderDeliveryDTO deliveryDTO)
	{
		return Task.FromResult(true);
	}
}
