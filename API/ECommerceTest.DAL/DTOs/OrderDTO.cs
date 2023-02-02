using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerceTest.DAL.DTOs;

public enum OrderPaymentType { Cash, Card }
public enum OrderDeliveryType { Pickup, NovaPoshta, UkrPoshta }

public record OrderPaymentDTO(OrderPaymentType type);

public record OrderDeliveryDTO(OrderDeliveryType type, string destination);
public record OrderProductDTO(ObjectId id, uint amount);

public class OrderDTO
{
	[BsonId]
	public ObjectId Id { get; set; }

	[BsonElement("payment")]
	public OrderPaymentDTO Payment { get; set; }

	[BsonElement("delivery")]
	public OrderDeliveryDTO Delivery { get; set; }

	[BsonElement("products")]
	public OrderProductDTO[] Products { get; set; }
}
