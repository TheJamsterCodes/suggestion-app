using SuggestionApp.Core.Interfaces;

namespace SuggestionApp.Core;

public class MockCategoryRepository : IBaseRepository<Category>
{
    public void Create(Category category)
    {
        Console.WriteLine($"{category.Name} category created!");
    }

    public void CreateMany(IList<Category> categories)
    {
        foreach (Category cat in categories)
        {
            Console.WriteLine($"{cat.Name} category created!");       
        }
    }

    public Task<bool> Delete(Category entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteMany(IList<Category> entities)
    {
        throw new NotImplementedException();
    }

    public Task<Category> Read(string id) => (Task<Category>)MockCategory.Categories.Where(c => c.Id == id);

    public async Task<IEnumerable<Category>> ReadMany()
    {
        var task = Task.FromResult<IEnumerable<Category>>(MockCategory.Categories);
        return await task;
    }

    public Task<bool> Update(Category entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateMany(IList<Category> entities)
    {
        throw new NotImplementedException();
    }
}
