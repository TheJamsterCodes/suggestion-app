namespace SuggestionApp.Core.Interfaces;

public interface ICategoryService
{
    void Create(Category category);
    void Create(IList<Category> categories);
    Task<Category> Get(string id);
    Task<IEnumerable<Category>> Get();
}