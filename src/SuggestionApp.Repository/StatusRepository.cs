
using Microsoft.Extensions.Caching.Memory;

namespace SuggestionApp.Repository;

public class StatusRepository : IRepository<Status>
{
    private readonly IMemoryCache _cache;
    private readonly string _cacheName = "StatusData";    
    private readonly ReplaceOptions _replaceOptions = new() { IsUpsert = true };
    private readonly IMongoCollection<Status> _statuses;

    public StatusRepository(IMemoryCache cache, IDbConnection db)
    {
        _cache = cache;
        _statuses= db.Statuses;
    }

    
    public async void Create(Status status)
    {
        await _statuses.InsertOneAsync(status);
        _cache.Remove(_cacheName);
    }

    
    public async void CreateMany(IList<Status> statuses)
    {
        await _statuses.InsertManyAsync(statuses);
        _cache.Remove(_cacheName);
    }

    
    public async Task<bool> Delete(Status status)
    {
        var result = await _statuses.DeleteOneAsync(s => s.Id == status.Id);
        return result.IsAcknowledged;
    }

    public Task<bool> DeleteMany(IList<Status> statuses)
    {
        throw new NotImplementedException();
    }

    public async Task<Status> Read(string id)
        => (Status)await _statuses.FindAsync(s => s.Id == id);

    public async Task<IEnumerable<Status>> ReadMany()
    {
        var output = _cache.Get<IEnumerable<Status>>(_cacheName);

        if (output is null)
        {
            output = (IEnumerable<Status>)await _statuses.FindAsync(_ => true);
            _cache.Set(_cacheName, output, TimeSpan.FromDays(1));
        }

        return output;
    }        

    
    public async Task<bool> Update(Status status)
    {
        var result = await _statuses.ReplaceOneAsync(s => s.Id == status.Id, status, _replaceOptions);

        if (result.IsAcknowledged) _cache.Remove(_cacheName);

        return result.IsAcknowledged;        
    }

    public Task<bool> UpdateMany(IList<Status> entities)
    {
        throw new NotImplementedException();
    }
}