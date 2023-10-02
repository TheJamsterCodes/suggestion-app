
using System.Diagnostics.CodeAnalysis;

namespace SuggestionApp.Core.Mocks;

public class MockUserRepository : IBaseRepository<User>
{
    public void Create(User entity)
    {
        throw new NotImplementedException();
    }

    public void CreateMany(IList<User> entities)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteMany(IList<User> entities)
    {
        throw new NotImplementedException();
    }

    public Task<User> Read(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> ReadMany()
    {
        var task = Task.FromResult<IEnumerable<User>>(FakeUser.Users);
        return await task;
    }

    public Task<bool> Update(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateMany(IList<User> entities)
    {
        throw new NotImplementedException();
    }
}
