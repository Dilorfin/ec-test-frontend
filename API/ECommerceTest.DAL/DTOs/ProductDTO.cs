using Newtonsoft.Json;

namespace ECommerceTest.DAL.DTOs;

public record ProductReviewDTO(
	[JsonProperty("id")] string Id,
	[JsonProperty("date")] string Date,
	[JsonProperty("userId")] string UserId,
	[JsonProperty("text")] string Text
);

public record ProductDTO(
	[JsonProperty("id")] string Id,
	[JsonProperty("title")] string Title,
	[JsonProperty("description")] string Description,
	[JsonProperty("imageUrl")] string ImageUrl,
	[JsonProperty("price")] long Price,
	[JsonProperty("amount")] uint Amount,
	[JsonProperty("reviews")] ProductReviewDTO[] Reviews
);
