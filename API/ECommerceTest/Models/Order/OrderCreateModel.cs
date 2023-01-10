namespace ECommerceTest.Models.Order;

public record OrderCreateResultModel(string orderId, InvoiceResultModel InvoiceResult);

public record OrderCreateModel(
	OrderPaymentModel payment,
	OrderDeliveryModel delivery,
	OrderProductModel[] products
);
