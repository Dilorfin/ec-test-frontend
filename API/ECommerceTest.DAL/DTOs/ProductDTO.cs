using Newtonsoft.Json;

namespace ECommerceTest.DAL.DTOs;

public record ProductDTO(
	[JsonProperty("id")] string Id,
	[JsonProperty("title")] string Title,
	[JsonProperty("description")] string Description,
	[JsonProperty("imageUrl")] string ImageUrl,
	[JsonProperty("price")] long Price
);
