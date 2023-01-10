using System;

namespace ECommerceTest.Models.Order;

public record OrderPaymentModel(string type);

public record OrderDeliveryModel(string type);
public record OrderProductModel(string id, uint amount);

public record OrderModel(
	string id,
	OrderPaymentModel payment,
	OrderDeliveryModel delivery,
	OrderProductModel[] products
);
