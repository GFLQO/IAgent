using MongoDB.Driver;
using IAgent.Domain.Entities;

namespace IAgent.Infra;

public class MongoContext 
{
    private readonly IMongoDatabase _database;

    public MongoContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<TaskType> TaskTypes =>
        _database.GetCollection<TaskType>("TaskTypes");

    public IMongoCollection<Job> Jobs =>
        _database.GetCollection<Job>("Jobs");

    public IMongoCollection<Agent> Agents =>
        _database.GetCollection<Agent>("Agents");
}
