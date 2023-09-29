using Microsoft.Extensions.Configuration;

namespace SuggestionApp.Repository;

public class MongoDbConnection : IDbConnection
{        
    private readonly IMongoDatabase _db;

    public IMongoClient Client { get; private set; }
    public string DatabaseName { get; private set; }
    public IMongoCollection<Category> Categories { get; private set; }
    public IMongoCollection<Suggestion> Suggestions { get; private set; }    
    public IMongoCollection<Status> Statuses { get; private set; }
    public IMongoCollection<User> Users { get; private set; }    
    
    public MongoDbConnection(IConfiguration config)
    {        
        try
        {
            Client = new MongoClient(config.GetConnectionString("MongoDB"));
            DatabaseName = config.GetSection("DatabaseName").Value;
            _db = Client.GetDatabase(DatabaseName);

            Categories = _db.GetCollection<Category>("categories");
            Suggestions = _db.GetCollection<Suggestion>("suggestions");
            Statuses = _db.GetCollection<Status>("statuses");
            Users = _db.GetCollection<User>("users");            
        }
        catch (MongoException)
        {
            throw;
        }        
    }
}