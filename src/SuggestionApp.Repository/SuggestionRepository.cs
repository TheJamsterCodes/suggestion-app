
using Microsoft.Extensions.Caching.Memory;

namespace SuggestionApp.Repository;

public class SuggestionRepository : IRepository<Suggestion>
{
    private readonly IMemoryCache _cache;
    private readonly string _cacheName = "Data";    
    private readonly ReplaceOptions _replaceOptions = new() { IsUpsert = true };
    private readonly IMongoCollection<Suggestion> _suggestions;

    public SuggestionRepository(IMemoryCache cache, IDbConnection db)
    {
        _cache = cache;
        _suggestions = db.Suggestions;
    }

    public async void Create(Suggestion suggestion)
    {
        await _suggestions.InsertOneAsync(suggestion);
        _cache.Remove(_cacheName);
    }

    public void CreateMany(IList<Suggestion> suggestions)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Suggestion suggestion)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteMany(IList<Suggestion> suggestions)
    {
        throw new NotImplementedException();
    }

    public async Task<Suggestion> Read(string id)
        => (Suggestion)await _suggestions.FindAsync(s => s.Id == id);

    public async Task<IEnumerable<Suggestion>> ReadMany()
    {
        var output = _cache.Get<IEnumerable<Suggestion>>(_cacheName);

        if (output is null)
        {
            output = (IEnumerable<Suggestion>)await _suggestions.FindAsync(s => !s.IsArchived);
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
}