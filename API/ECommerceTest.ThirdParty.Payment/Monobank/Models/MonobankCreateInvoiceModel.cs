using Newtonsoft.Json;

namespace ECommerceTest.ThirdParty.Payment.Monobank.Models;

internal record MonobankCreateInvoiceModel
{
	// Сума оплати у мінімальних одиницях (копійки для гривні)
	[JsonProperty("amount")]
	public long InvoiceAmount { get; set; }

	// ISO 4217 код валюти, за замовчуванням 980 (гривня)
	[JsonProperty("ccy")] public int CurrencyISO4217 => 980;

	// Корзина замовленя
	[JsonProperty("merchantPaymInfo")]
	public MonobankOrderModel Order { get; set; }

	// Адреса для повернення (GET) - на цю адресу буде переадресовано користувача після завершення оплати (у разі успіху або помилки)
	[JsonProperty("redirectUrl")]
	public string RedirectUrl { get; set; }

	// Адреса для CallBack (POST) – на цю адресу буде надіслано дані про стан платежу при кожній зміні статусу. Зміст тіла запиту ідентичний відповіді запиту “перевірки статусу рахунку”.
	[JsonProperty("webHookUrl")]
	public string WebHookUrl { get; set; }

	// Строк дії в секундах, за замовчуванням рахунок перестає бути дійсним через 24 години
	[JsonProperty("validity")]
	public long Validity { get; set; }

	// Тип операції. Enum: "debit" "hold" 
	[JsonProperty("paymentType")]
	public string PaymentType => "debit";

	// Ідентифікатор QR-каси для встановлення суми оплати на існуючих QR-кас
	[JsonProperty("qrId")]
	public string QRId => null;
}
