using Newtonsoft.Json;

namespace ECommerceTest.Models.Product;

public record ProductReviewModel(
	[JsonProperty("id")] string Id,
	[JsonProperty("date")] string Date,
	[JsonProperty("userId")] string UserId,
	[JsonProperty("text")] string Text
);

public record ProductDetailedModel(
	[JsonProperty("id")] string Id,
	[JsonProperty("title")] string Title,
	[JsonProperty("description")] string Description,
	[JsonProperty("imageUrl")] string ImageUrl,
	[JsonProperty("price")] long Price,
	[JsonProperty("amount")] uint Amount,
	[JsonProperty("reviews")] ProductReviewModel[] Reviews
);
