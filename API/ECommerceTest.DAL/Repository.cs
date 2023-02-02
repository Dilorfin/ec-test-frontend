using MongoDB.Driver;

namespace ECommerceTest.DAL;

public class Repository
{
	protected static readonly string ConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
	protected static readonly string DatabaseName = "db";

	protected static readonly MongoClient Client = new MongoClient(ConnectionString);
	protected static readonly IMongoDatabase Database = Client.GetDatabase(DatabaseName);
}
