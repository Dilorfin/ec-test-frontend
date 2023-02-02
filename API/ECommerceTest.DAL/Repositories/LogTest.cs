using ECommerceTest.DAL.DTOs;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ECommerceTest.DAL.Repositories;

public class LogTest : Repository
{
	private record LogData(ObjectId _id, string text);

	private readonly IMongoCollection<LogData> _collection;

	public LogTest()
	{
		_collection = Database.GetCollection<LogData>("logs");
	}

	public async void Log(string str)
	{
		await _collection.InsertOneAsync(
			new LogData(ObjectId.GenerateNewId(), str)
		);
	}
}
