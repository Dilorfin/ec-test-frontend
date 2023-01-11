using Newtonsoft.Json;

namespace ECommerceTest.Models.Product;

public record ProductListModel(
	[JsonProperty("id")] string Id,
	[JsonProperty("title")] string Title,
	[JsonProperty("imageUrl")] string ImageUrl,
	[JsonProperty("price")] long Price
);
