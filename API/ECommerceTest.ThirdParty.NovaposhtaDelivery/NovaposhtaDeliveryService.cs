using ECommerceTest.DAL.DTOs;
using Newtonsoft.Json;
using System.Text;

namespace ECommerceTest.ThirdParty.Delivery
{
	public class NovaposhtaDeliveryService : IDeliveryService
	{
		private const string ApiUrl = "https://api.novaposhta.ua/v2.0/json/";

		public async Task<bool> ValidateOrderDelivery(OrderDeliveryDTO deliveryDTO)
		{
			using HttpClient client = new();
			var model = new
			{
				modelName = "Address",
				calledMethod = "getWarehouses",
				methodProperties = new
				{
					WarehouseIndex = deliveryDTO.destination,
					Limit = 5
				}
			};
			string pJsonContent = JsonConvert.SerializeObject(model);
			HttpContent httpContent = new StringContent(pJsonContent, Encoding.UTF8, "application/json");
			var response = await client.PostAsync(ApiUrl, httpContent);
			var responseBodyString = await response.Content.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode)
			{
				throw new Exception(responseBodyString);
			}

			var responseBody = JsonConvert.DeserializeObject<NovaposhtaResponse<NovaposhtaWarehouse>>(responseBodyString);
			return responseBody is { data.Length: 1, errors.Length: <= 0 };
		}
	}
}
