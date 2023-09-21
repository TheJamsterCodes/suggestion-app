using Microsoft.Extensions.Configuration;

namespace SuggestionApp.Repository;

public class DbConnection : IDbConnection
{
    private readonly IConfiguration _config;
    private readonly IMongoDatabase _db;
    private readonly string _connectionId = "MongoDB";

    public MongoClient Client { get; private set; }
    public string DbName { get; private set; }

    public IMongoCollection<Category> CategoryCollection { get; private set; }
    public string CategoryCollectionName { get; private set; } = "categories";
    public IMongoCollection<Suggestion> SuggestionCollection { get; private set; }
    public string SuggestionCollectionName { get; private set; } = "suggestions";
    public IMongoCollection<Status> StatusCollection { get; private set; }
    public string StatusCollectionName { get; private set; } = "statuses";
    public IMongoCollection<User> UserCollection { get; private set; }
    public string UserCollectionName { get; private set; } = "users";
    
    public DbConnection(IConfiguration config)
    {
        _config = config;
        Client = new MongoClient(_config.GetConnectionString(_connectionId));
        DbName = _config["DatabaseName"];
        _db = Client.GetDatabase(DbName);

        CategoryCollection = _db.GetCollection<Category>(CategoryCollectionName);
        SuggestionCollection = _db.GetCollection<Suggestion>(SuggestionCollectionName);
        StatusCollection = _db.GetCollection<Status>(StatusCollectionName);
        UserCollection = _db.GetCollection<User>(UserCollectionName);
    }
}