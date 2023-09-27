namespace SuggestionApp.Repository;

public interface ISuggestionRepository
{
    void CreateWithAuthor(Suggestion suggestion, User user);
    void UpdateVote(Suggestion suggestion, User user);
}