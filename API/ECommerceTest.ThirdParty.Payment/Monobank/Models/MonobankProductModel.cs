using Newtonsoft.Json;

namespace ECommerceTest.ThirdParty.Payment.Monobank.Models;

internal record MonobankProductModel
{
	// Назва товару
	[JsonProperty("name")]
	public string Name { get; set; }

	// Кількість
	[JsonProperty("qty")]
	public int Quantity { get; set; }

	// Сума у мінімальних одиницях валюти за одиницю товару
	[JsonProperty("sum")]
	public long PricePerItem { get; set; }

	// Лінк на зображення товару
	[JsonProperty("icon")]
	public string ImageUrl { get; set; }

	// Назва одиниці вимiру товару
	[JsonProperty("unit")]
	public string Unit { get; set; }

	// Код товару, обов'язковий для фіскалізації
	[JsonProperty("code")]
	public string Code { get; set; }

	// Значення штрих-коду, може бути потрібно для фіскалізації
	[JsonProperty("barcode")]
	public string Barcode { get; set; }

	// Текст, що передує назві товару, може бути потрібний для фіскалізації
	[JsonProperty("header")]
	public string NamePrefix { get; set; }

	// Текст, після товару, може бути потрібний для фіскалізації
	[JsonProperty("footer")]
	public string NamePostfix { get; set; }

	// Масив податкових ставок, які було обрано на порталі UKey при реєстрації каси
	[JsonProperty("tax")]
	public int[] Tax { get; set; }

	// Код УКТ ЗЕД
	[JsonProperty("uktzed")]
	public string UKTZED { get; set; }
}
