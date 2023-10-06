namespace SuggestionApp.Core.Interfaces;

public interface ISuggestionRepository
{
    Task<bool> AdminUpdate(Suggestion suggestion, string property);
    Task CreateWithAuthor(Suggestion suggestion, User user);    
    Task UpdateVote(Suggestion suggestion, User user);
}