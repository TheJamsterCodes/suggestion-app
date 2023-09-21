namespace SuggestionApp.Repository.Interfaces;

public interface IDbConnection
{
    MongoClient Client { get; }
    string DbName { get; }
    IMongoCollection<Category> CategoryCollection { get; }
    string CategoryCollectionName { get; }
    IMongoCollection<Suggestion> SuggestionCollection { get; }
    string SuggestionCollectionName { get; }
    IMongoCollection<Status> StatusCollection { get; }
    string StatusCollectionName { get; }
    IMongoCollection<User> UserCollection { get; }
    string UserCollectionName { get; }
}