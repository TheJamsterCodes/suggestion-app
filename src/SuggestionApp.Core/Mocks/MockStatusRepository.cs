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

    public async Task<Status> Read(string id)
    {
        var task = Task.FromResult(MockStatus.Statuses.First(s => s.Id == id));
        return await task;
    }

    public async Task<IEnumerable<Status>> ReadMany()
    {
        var task = Task.FromResult<IEnumerable<Status>>(MockStatus.Statuses);
        return await task;
    }

    public Task<bool> Update(Status entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateMany(IList<Status> entities)
    {
        throw new NotImplementedException();
    }
}