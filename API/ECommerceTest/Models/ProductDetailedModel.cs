using Newtonsoft.Json;

namespace ECommerceTest.Models;

public record ProductDetailedModel(
	[JsonProperty("id")] string Id,
	[JsonProperty("title")] string Title,
	[JsonProperty("description")] string Description,
	[JsonProperty("imageUrl")] string ImageUrl,
	[JsonProperty("price")] string Price
);
