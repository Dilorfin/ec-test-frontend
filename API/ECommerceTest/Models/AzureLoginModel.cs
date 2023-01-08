namespace ECommerceTest.Models;

public record AzureLoginModel(
	string identityProvider,
	string userId,
	string userDetails,
	string[] userRoles
);
