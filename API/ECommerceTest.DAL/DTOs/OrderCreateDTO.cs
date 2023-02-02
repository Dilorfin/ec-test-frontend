using ECommerceTest.ThirdParty.Payment.DTOs;

namespace ECommerceTest.DAL.DTOs;

public record OrderCreateResultDTO(string orderId, InvoiceResultDTO invoice);

public record OrderCreateDTO(
	OrderPaymentDTO payment,
	OrderDeliveryDTO delivery,
	OrderProductDTO[] products
);
