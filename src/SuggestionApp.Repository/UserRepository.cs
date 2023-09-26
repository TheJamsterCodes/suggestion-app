using Microsoft.Extensions.Caching.Memory;

namespace SuggestionApp.Repository;

public class UserRepository : IRepository<User>
{
    private readonly IMemoryCache _cache;
    private readonly string _cacheName = "UserData";
    private readonly ReplaceOptions _replaceOptions = new() { IsUpsert = true };
    private readonly IMongoCollection<User> _users;

    public UserRepository(IMemoryCache cache, IDbConnection db)
    {
        _cache = cache;
        _users = db.Users;
    }
    
    public async void Create(User user)
    {
        await _users.InsertOneAsync(user);
        _cache.Remove(_cacheName);
    }

    public async void CreateMany(IList<User> users)
    {
        await _users.InsertManyAsync(users);
        _cache.Remove(_cacheName);
    }
    
    public async Task<bool> Delete(User user)
    {
        var result = await _users.DeleteOneAsync(u => u.Id == user.Id);

        if (result.IsAcknowledged) _cache.Remove(_cacheName);

        return result.IsAcknowledged;
    }

    public Task<bool> DeleteMany(IList<User> users)
    {
        throw new NotImplementedException();
    }    
    
    public async Task<User> Read(string id)
        => (User)await _users.FindAsync(u => u.Id == id);

    public async Task<IEnumerable<User>> ReadMany()
    {
        var output = _cache.Get<IEnumerable<User>>(_cacheName);

        if (output is null)
        {
            output = (IEnumerable<User>)await _users.FindAsync(_ => true);
            _cache.Set(_cacheName, output, TimeSpan.FromMinutes(5));
        }

        return output;
    }        
    
    public async Task<bool> Update(User user)
    {
        var result = await _users.ReplaceOneAsync(u => u.Id == user.Id, user, _replaceOptions);

        if (result.IsAcknowledged) _cache.Remove(_cacheName);

        return result.IsAcknowledged;
    }

    public Task<bool> UpdateMany(IList<User> users)
    {
        throw new NotImplementedException();
    }
}