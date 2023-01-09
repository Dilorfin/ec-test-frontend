using Microsoft.Azure.Cosmos;

namespace ECommerceTest.DAL;

public class Repository
{
	protected readonly CosmosClient Client;
	protected readonly Container Container;
	protected readonly Database Database;
	protected const string PartionKeyName = "/id";

	protected readonly string ConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
	protected readonly string DatabaseName;
	protected readonly string ContainerName;

	protected Repository(string databaseName, string containerName)
	{
		DatabaseName = databaseName;
		ContainerName = containerName;

		Client = new CosmosClient(ConnectionString);
		
		Database = Client.CreateDatabaseIfNotExistsAsync(DatabaseName).Result.Database;
		Container = Database.CreateContainerIfNotExistsAsync(ContainerName, PartionKeyName).Result.Container;
	}
}
