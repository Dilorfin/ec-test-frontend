using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API.Payment
{
	public static class CreateInvoice
    {
	    private record MonobankProductModel
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

	    private record MonobankOrderModel
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

	    private record MonobankCreateInvoiceModel
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

	    private static MonobankCreateInvoiceModel MoqModel()
	    {
		    return new MonobankCreateInvoiceModel()
		    {
				InvoiceAmount = 4200,
				RedirectUrl = "",
				WebHookUrl = "",
				Validity = 3600,
				Order = new MonobankOrderModel()
				{
					OrderId = "84d0070ee4e44667b31371d8f8813947",
					Description = "Покупка щастя",
					Products = new[]
					{
						new MonobankProductModel()
						{
							Name = "Табуретка",
							Quantity = 2,
							PricePerItem = 2100,
							ImageUrl = "chrome://branding/content/about-logo.png",
							Unit = "шт.",
							Code = "d21da1c47f3c45fca10a10c32518bdeb",
							Barcode =  "3b2a558cc6e44e218cdce301d80a1779",
							NamePrefix = "Хідер",
							NamePostfix = "Футер",
							Tax = new []{0},
							UKTZED = "uktzedcode"
						}
					}
				}
		    };
	    }

        [FunctionName("CreateInvoice")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
	        using HttpClient client = new();
	        
	        client.DefaultRequestHeaders.Add("X-Token", Environment.GetEnvironmentVariable("MONOBANK_TOKEN"));
            string pJsonContent = JsonConvert.SerializeObject(MoqModel());

            log.LogInformation(pJsonContent);

	        HttpContent httpContent = new StringContent(pJsonContent, Encoding.UTF8, "application/json");
            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = new Uri("https://api.monobank.ua/api/merchant/invoice/create");
            httpRequestMessage.Content = httpContent;
            var response = await client.SendAsync(httpRequestMessage);
            
            return new JsonResult(await response.Content.ReadAsStringAsync());
        }

        [FunctionName("CreateInvoiceWebhook")]
        public static async Task<IActionResult> CreateInvoiceWebhook(
	        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
	        ILogger log)
        {
	        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
	        
	        log.LogDebug(requestBody);
	        return new OkResult();
        }
    }
}
