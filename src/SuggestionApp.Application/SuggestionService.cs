namespace SuggestionApp.Application;

public class SuggestionService
{
    public SuggestionService()
    {
        
    }

    public void AuthorSuggestion(Suggestion suggestion, User user)
    {
        var basicSuggestion = new BasicSuggestion(suggestion);
        user.AuthoredSuggestions.Add(basicSuggestion);

    }
}