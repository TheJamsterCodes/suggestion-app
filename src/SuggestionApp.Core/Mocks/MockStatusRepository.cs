using SuggestionApp.Core.Interfaces;

namespace SuggestionApp.Core;

public class MockStatusRepository : IBaseRepository<Status>
{
    public void Create(Status status)
    {
        Console.WriteLine($"{status.Name} created!");
    }

    public void CreateMany(IList<Status> statuses)
    {
        foreach (Status status in statuses)
        {
            Console.WriteLine($"{status.Name} created!");
        }
    }

    public Task<bool> Delete(Status entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteMany(IList<Status> entities)
    {
        throw new NotImplementedException();
    }

    public Task<Status> Read(string id) => (Task<Status>)MockStatus.Statuses.Where(s => s.Id == id);

    public Task<IEnumerable<Status>> ReadMany() => (Task<IEnumerable<Status>>)MockStatus.Statuses;

    public Task<bool> Update(Status entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateMany(IList<Status> entities)
    {
        throw new NotImplementedException();
    }
}
