using SuggestionApp.Core.Entities;

namespace SuggestionApp.Core.Interfaces;

public interface ISuggestionRepository
{
    void CreateWithAuthor(Suggestion suggestion, User user);
    void UpdateVote(Suggestion suggestion, User user);
}