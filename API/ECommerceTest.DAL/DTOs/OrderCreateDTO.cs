using ECommerceTest.ThirdParty.Payment.DTOs;

namespace ECommerceTest.DAL.DTOs;

public record OrderCreateResultDTO(Guid? orderId, InvoiceResultDTO invoice);

public record OrderCreateDTO(
	OrderPaymentDTO payment,
	OrderDeliveryDTO delivery,
	OrderProductDTO[] products
);
