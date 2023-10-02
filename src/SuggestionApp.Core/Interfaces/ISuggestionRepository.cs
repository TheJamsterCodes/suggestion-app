namespace SuggestionApp.Core.Interfaces;

public interface ISuggestionRepository
{
    Task CreateWithAuthor(Suggestion suggestion, User user);
    Task UpdateVote(Suggestion suggestion, User user);
}