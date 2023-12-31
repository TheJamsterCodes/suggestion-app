
using Microsoft.Extensions.Caching.Memory;

namespace SuggestionApp.Repository;

public class SuggestionRepository : ISuggestionRepository, IBaseRepository<Suggestion>
{
    private readonly IMemoryCache _cache;
    private readonly string _cacheName = "SuggestionData";    
    private readonly IDbConnection _db;
    private readonly ReplaceOptions _replaceOptions = new() { IsUpsert = true };
    private readonly IMongoCollection<Suggestion> _suggestions;

    public SuggestionRepository(IMemoryCache cache, IDbConnection db)
    {
        _cache = cache;
        _db = db;
        _suggestions = _db.Suggestions;
    }

    /// <summary>
    /// Inserts one Suggestion document in the Suggestions collection.
    /// This method ignores updating the Author document.
    /// </summary>
    /// <param name="suggestion"></param>
    public async void Create(Suggestion suggestion)
    {
        await _suggestions.InsertOneAsync(suggestion);        
    }

    public void CreateMany(IList<Suggestion> suggestions)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Inserts one Suggestion into the Suggestions collection
    /// and updates the User documents AuthoredSuggestions field array.
    /// </summary>
    /// <param name="suggestion"></param>
    public async Task CreateWithAuthor(Suggestion suggestion, User user)
    {
        using IClientSessionHandle session = await _db.Client.StartSessionAsync();

        IMongoDatabase sessionDb = _db.Client.GetDatabase(_db.DatabaseName);
        var suggestions = sessionDb.GetCollection<Suggestion>("suggestions");
        var users = sessionDb.GetCollection<User>("users");

        session.StartTransaction();        

        try
        {
            await suggestions.InsertOneAsync(suggestion);            
            await users.ReplaceOneAsync(u => u.Id == user.Id, user, _replaceOptions);

            await session.CommitTransactionAsync();
        }
        catch (Exception)
        {
            await session.AbortTransactionAsync();
            throw;
        }
    }    

    public Task<bool> Delete(Suggestion suggestion)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteMany(IList<Suggestion> suggestions)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a Suggestion based on ObjectId.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Suggestion> Read(string id)
        => (Suggestion)await _suggestions.FindAsync(s => s.Id == id);

    public async Task<IEnumerable<Suggestion>> ReadMany()
    {
        var output = _cache.Get<IEnumerable<Suggestion>>(_cacheName);

        if (output is null)
        {
            output = (IEnumerable<Suggestion>)await _suggestions.FindAsync(_ => true);
            _cache.Set(_cacheName, output, TimeSpan.FromMinutes(1));
        }

        return output;
    }
    
    public async Task<bool> Update(Suggestion suggestion)
    {
        var result = await _suggestions.ReplaceOneAsync(s => s.Id == suggestion.Id, suggestion, _replaceOptions);

        if (result.IsAcknowledged) _cache.Remove(_cacheName);

        return result.IsAcknowledged;
    }

    public Task<bool> UpdateMany(IList<Suggestion> entities)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateVote(Suggestion suggestion, User user)
    {        
        using IClientSessionHandle session = await _db.Client.StartSessionAsync();

        var db = _db.Client.GetDatabase(_db.DatabaseName);
        var suggestions = db.GetCollection<Suggestion>("suggestions");
        var users = db.GetCollection<User>("users");

        session.StartTransaction();

        try
        {            
            _ = await suggestions.ReplaceOneAsync(s => s.Id == suggestion.Id, suggestion);
            _ = await users.ReplaceOneAsync(u => u.Id == user.Id, user);

            await session.CommitTransactionAsync();
            _cache.Remove(_cacheName);
        }
        catch (Exception)
        {
            await session.AbortTransactionAsync();
            throw;
        }    
    }
}