namespace SuggestionApp.Application;

/// <summary>
/// A class pertaining to use cases of <c>Category</c>.
/// </summary>
public class CategoryService : ICategoryService
{
    private readonly IBaseRepository<Category> _categoryRepo;

    public CategoryService(IBaseRepository<Category> categoryRepo) => _categoryRepo = categoryRepo;

    public void Create(Category category)
    {
        _categoryRepo.Create(category);
    }

    public void Create(IList<Category> categories)
    {
        _categoryRepo.CreateMany(categories);
    }

    public async Task<Category> Get(string id) => await _categoryRepo.Read(id);
    public async Task<IEnumerable<Category>> Get() => await _categoryRepo.ReadMany();
}