using ECommerceTest.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ECommerceTest.Common;

public static class AzureAuthUtils
{
	public static AzureLoginModel GetAzureUserFromRequest(HttpRequest req)
	{
		var matches = req.Headers["x-ms-client-principal"];
		if (matches.Count <= 0)
			return null;
		var header = matches[0];

		var plainTextBytes = System.Convert.FromBase64String(header);
		var jsonString = System.Text.Encoding.UTF8.GetString(plainTextBytes);
		return JsonConvert.DeserializeObject<AzureLoginModel>(jsonString);
	}
}
