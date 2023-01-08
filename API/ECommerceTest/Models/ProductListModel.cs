using Newtonsoft.Json;

namespace ECommerceTest.Models;

public record ProductListModel(
	[JsonProperty("id")] string Id,
	[JsonProperty("title")] string Title,
	[JsonProperty("imageUrl")] string ImageUrl,
	[JsonProperty("price")] string Price
);
