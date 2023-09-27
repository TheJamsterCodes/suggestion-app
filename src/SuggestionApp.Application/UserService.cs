namespace SuggestionApp.Application;

public class UserService : IUserService
{
    private readonly IBaseRepository<User> _userRepo;

    public UserService(IBaseRepository<User> userRepo) => _userRepo = userRepo;

    /// <summary>
    /// Gets a <c>User</c> by Azure ActiveDirectory B2C ObjectIdentifier id.
    /// </summary>
    /// <param name="objectIdentifier"></param>
    /// <returns>A <c>User</c></returns>
    public async Task<User> GetByAuth(string objectIdentifier)
    {
        var users = await _userRepo.ReadMany();
        return users.Where(u => u.ObjectIdentifier == objectIdentifier).First();
    }
}