using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerceTest.DAL.DTOs;

public class ProductReviewDTO
{
	[BsonId]
	public ObjectId Id { get; set; }
	[BsonElement("date")]
	public string Date { get; set; }
	[BsonElement("userId")]
	public string UserId { get; set; }
	[BsonElement("text")]
	public string Text { get; set; }
};

public class ProductDTO
{
	[BsonId]
	public ObjectId Id { get; set; }
	[BsonElement("title")]
	public string Title { get; set; }
	[BsonElement("description")]
	public string Description { get; set; }
	[BsonElement("imageUrl")]
	public string ImageUrl { get; set; }
	[BsonElement("price")]
	public long Price { get; set; }
	[BsonElement("amount")]
	public uint Amount { get; set; }
	[BsonElement("reviews")]
	public ObjectId[] Reviews { get; set; }
};
