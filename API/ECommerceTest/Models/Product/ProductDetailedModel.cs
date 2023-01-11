using Newtonsoft.Json;

namespace ECommerceTest.Models.Product;

public record ProductDetailedModel(
	[JsonProperty("id")] string Id,
	[JsonProperty("title")] string Title,
	[JsonProperty("description")] string Description,
	[JsonProperty("imageUrl")] string ImageUrl,
	[JsonProperty("price")] long Price
);
