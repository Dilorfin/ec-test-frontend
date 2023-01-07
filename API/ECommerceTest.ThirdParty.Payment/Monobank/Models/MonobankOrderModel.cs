using Newtonsoft.Json;

namespace ECommerceTest.ThirdParty.Payment.Monobank.Models;

internal record MonobankOrderModel
{
	// Номер чека, замовлення, тощо; визначається мерчантом
	[JsonProperty("reference")]
	public string OrderId { get; set; }

	// Призначення платежу
	[JsonProperty("destination")]
	public string Description { get; set; }

	// Склад замовлення, використовується для відображення кошика замовлення
	[JsonProperty("basketOrder")]
	public MonobankProductModel[] Products { get; set; }
}
