namespace SuggestionApp.Core.Interfaces;

public interface IUserService
{
    Task<User> GetByAuth(string objectIdentifier);
}