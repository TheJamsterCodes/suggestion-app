namespace SuggestionApp.Core.Interfaces;

public interface IBaseRepository<Entity>  where Entity : class
{
    void Create(Entity entity);
    void CreateMany(IList<Entity> entities);
    Task<bool> Delete(Entity entity);
    Task<bool> DeleteMany(IList<Entity> entities);
    Task<Entity> Read(string id);
    Task<IEnumerable<Entity>> ReadMany();
    Task<bool> Update(Entity entity);
    Task<bool> UpdateMany(IList<Entity> entities);
}