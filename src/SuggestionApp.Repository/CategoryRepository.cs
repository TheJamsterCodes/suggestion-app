
using Microsoft.Extensions.Caching.Memory;

namespace SuggestionApp.Repository;

public class CategoryRepository : IBaseRepository<Category>
{
    private readonly IMemoryCache _cache;
    private readonly string _cacheName = "CategoryData";
    private readonly IMongoCollection<Category> _categories;
    private readonly ReplaceOptions _replaceOptions = new() { IsUpsert = true };

    public CategoryRepository(IMemoryCache cache, IDbConnection db)
    {
        _cache = cache;
        _categories = db.Categories;              
    }

    public async void Create(Category category)
    {
        await _categories.InsertOneAsync(category);
        _cache.Remove(_cacheName);
    }

    public async void CreateMany(IList<Category> categories)
    {
        await _categories.InsertManyAsync(categories);
        _cache.Remove(_cacheName);
    }
    
    public async Task<bool> Delete(Category category)
    {
        var result = await _categories.DeleteOneAsync(c => c.Id == category.Id);
        return result.IsAcknowledged;        
    }

    public Task<bool> DeleteMany(IList<Category> categories)
    {
        throw new NotImplementedException();
    }

    public async Task<Category> Read(string id)
        => (Category)await _categories.FindAsync(c => c.Id == id);

    public async Task<IEnumerable<Category>> ReadMany()
    {
        try
        {
            var output = _cache.Get<IEnumerable<Category>>(_cacheName);

            if (output is null)
            {
                IAsyncCursor<Category> cursor = await _categories.FindAsync(_ => true);
                output = cursor.Current;
                _cache.Set(_cacheName, output, TimeSpan.FromDays(1));
            }

            return output;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> Update(Category category)
    {
        var result = await _categories.ReplaceOneAsync(c => c.Id == category.Id, category, _replaceOptions);

        if (result.IsAcknowledged) _cache.Remove(_cacheName);

        return result.IsAcknowledged;
    }

    public Task<bool> UpdateMany(IList<Category> categories)
    {
        throw new NotImplementedException();
    }
}