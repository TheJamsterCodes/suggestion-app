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
    /// and persists both entities to the database.
    /// </summary>
    /// <param name="suggestion"></param>
    /// <param name="user"></param>
    public void AuthorSuggestion(Suggestion suggestion, User user)
    {
        var basicSuggestion = new BasicSuggestion(suggestion);
        user.AuthoredSuggestions.Add(basicSuggestion);
        _suggestRepo.CreateWithAuthor(suggestion, user);
    }

    /// <summary>
    /// Add/remove the voter's User.Id from Suggestion.Votes,
    /// add/remove BasicSuggestion from User,
    /// and persists the both entities to the database.
    /// </summary>
    /// <param name="suggestion"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public bool Vote(Suggestion suggestion, User user, string votingUserId)
    {
        bool isUpvote = suggestion.Votes.Add(votingUserId);

        if (isUpvote)
        {
            user.VotedSuggestions.Add(new BasicSuggestion(suggestion));
        }
        else
        {
            _ = suggestion.Votes.Remove(votingUserId);

            var removedSuggestion = user.VotedSuggestions.Where(vs => vs.Id == suggestion.Id).First();
            user.VotedSuggestions.Remove(removedSuggestion);            
        }

        _suggestRepo.UpdateVote(suggestion, user);

        return isUpvote;
    }
}