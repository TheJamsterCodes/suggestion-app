using SuggestionApp.Core.Entities;

namespace SuggestionApp.Core.Interfaces;

public interface IDbConnection
{
    IMongoClient Client { get; }
    IMongoCollection<Category> Categories { get; }
    IMongoCollection<Suggestion> Suggestions { get; }    
    IMongoCollection<Status> Statuses { get; }
    IMongoCollection<User> Users { get; }        
}