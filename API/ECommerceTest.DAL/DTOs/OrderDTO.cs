namespace ECommerceTest.DAL.DTOs;

public enum OrderPaymentType { Cash, Card }
public enum OrderDeliveryType { Pickup, NovaPoshta, UkrPoshta }

public record OrderPaymentDTO(OrderPaymentType type);

public record OrderDeliveryDTO(OrderDeliveryType type);
public record OrderProductDTO(Guid id, uint amount);

public record OrderDTO(
	Guid id,
	OrderPaymentDTO payment,
	OrderDeliveryDTO delivery,
	OrderProductDTO[] products
);
