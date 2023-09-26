namespace SuggestionApp.Core.Interfaces;

public interface IRepository<IEntity> 
{
    void Create(IEntity entity);
    void CreateMany(IList<IEntity> entities);
    Task<bool> Delete(IEntity entity);
    Task<bool> DeleteMany(IList<IEntity> entities);
    Task<IEntity> Read(string id);
    Task<IEnumerable<IEntity>> ReadMany();
    Task<bool> Update(IEntity entity);
    Task<bool> UpdateMany(IList<IEntity> entities);
}