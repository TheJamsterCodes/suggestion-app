namespace SuggestionApp.Application;

/// <summary>
/// A class pertaining to use cases of suggestions.
/// </summary>
public class SuggestionService
{
    private readonly ISuggestionRepository _suggestRepo;

    public SuggestionService(ISuggestionRepository suggestRepo) => _suggestRepo = suggestRepo;

    /// <summary>
    /// Adds a BasicSuggestion to the User.AuthoredSuggestions list
    /// and persists both entities in the database.
    /// </summary>
    /// <param name="suggestion"></param>
    /// <param name="user"></param>
    public void AuthorSuggestion(Suggestion suggestion, User user)
    {
        var basicSuggestion = new BasicSuggestion(suggestion);
        user.AuthoredSuggestions.Add(basicSuggestion);
        _suggestRepo.CreateWithAuthor(suggestion, user);
    }
}