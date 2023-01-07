using ECommerceTest.ThirdParty.Payment.DTOs;
using ECommerceTest.ThirdParty.Payment.Monobank.Models;
using Newtonsoft.Json;
using System.Text;

namespace ECommerceTest.ThirdParty.Payment.Monobank;

public class MonobankPaymentService : IPaymentService
{
	private const string MonobankApiUri = "https://api.monobank.ua/api";

	internal record MonobankInvoiceModel(string invoiceId, string pageUrl);

	internal record MonobankErrorResponse(string errCode, string errText);

	public async Task<InvoiceDTO> CreateInvoiceAsync(Uri redirectUri, Uri callbackUri)
	{
		using HttpClient client = new();

		client.DefaultRequestHeaders.Add("X-Token", Environment.GetEnvironmentVariable("MONOBANK_TOKEN"));

		var model = MoqModel() with
		{
			WebHookUrl = callbackUri.ToString(),
			RedirectUrl = redirectUri.ToString()
		};
		string pJsonContent = JsonConvert.SerializeObject(model);

		HttpContent httpContent = new StringContent(pJsonContent, Encoding.UTF8, "application/json");

		var httpRequestMessage = new HttpRequestMessage();
		httpRequestMessage.Method = HttpMethod.Post;
		httpRequestMessage.RequestUri = new Uri($"{MonobankApiUri}/merchant/invoice/create");
		httpRequestMessage.Content = httpContent;

		var response = await client.SendAsync(httpRequestMessage);
		var responseBody = await response.Content.ReadAsStringAsync();
		if (!response.IsSuccessStatusCode)
		{
			throw new Exception(responseBody);
		}

		var monoInvoice = JsonConvert.DeserializeObject<MonobankInvoiceModel>(responseBody);
		return new InvoiceDTO(monoInvoice.invoiceId, monoInvoice.pageUrl);
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
}
