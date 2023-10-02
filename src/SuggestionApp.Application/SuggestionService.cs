namespace SuggestionApp.Application;

/// <summary>
/// A class pertaining to use cases of <c>Suggestion</c>.
/// </summary>
public class SuggestionService : ISuggestionService
{
    private readonly IBaseRepository<Suggestion> _baseRepo;
    private readonly ISuggestionRepository _suggestRepo;

    public SuggestionService(IBaseRepository<Suggestion> baseRepo, ISuggestionRepository suggestRepo)
    {
        _baseRepo = baseRepo;
        _suggestRepo = suggestRepo;
    }

    /// <summary>
    /// Adds a <c>BasicSuggestion</c> to the <c>User.AuthoredSuggestions</c> list
    /// and persists both entities to the database.
    /// </summary>
    /// <param name="suggestion"></param>
    /// <param name="user"></param>
    public async Task AuthorSuggestion(Suggestion suggestion, User user)
    {
        var basicSuggestion = new BasicSuggestion(suggestion);
        user.AuthoredSuggestions.Add(basicSuggestion);
        await _suggestRepo.CreateWithAuthor(suggestion, user);
    }

    /// <summary>
    /// Gets a <c>Suggestion</c> based on Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>A <c>Suggestion</c>.</returns>
    public async Task<Suggestion> Get(string id) => await _baseRepo.Read(id);    

    /// <summary>
    /// Gets a list of <c>Suggestion</c> where <c>IsApprovedForRelease == true</c>.
    /// </summary>
    /// <returns>An enumerable list of <c>Suggestion</c>.</returns>
    public async Task<IEnumerable<Suggestion>> GetApprovedForRelease()
    {
        var suggestions = await _baseRepo.ReadMany();
        return suggestions.Where(s => s.IsApprovedForRelease).OrderByDescending(s => s.DateCreated);
    }

    /// <summary>
    /// Get a list of <c>Suggestion</c> for a specific User
    /// regardless of status.
    /// </summary>
    /// <returns>A list of <c>Suggestion</c>.</returns>
    public async Task<IEnumerable<Suggestion>> GetByUserId(string id)
    {
        var suggestions = await _baseRepo.ReadMany();
        return suggestions.Where(s => s.Author.Id == id).OrderByDescending(s => s.DateCreated);
    }

    /// <summary>
    /// Gets a list of <c>Suggestion</c> where <c>IsApprovedForRelease == false</c>
    /// and <c>IsRejected == false</c>.
    /// </summary>
    /// <returns>An enumerable list of <c>Suggestion</c>.</returns>
    public async Task<IEnumerable<Suggestion>> GetWaitingForApproval()
    {
        var suggestions = await _baseRepo.ReadMany();
        return suggestions.Where(s => !s.IsApprovedForRelease && !s.IsRejected).OrderBy(s => s.DateCreated);
    }    

    /// <summary>
    /// Add/remove the voter's <c>User.Id</c> from <c>Suggestion.Votes</c>,
    /// add/remove <c>BasicSuggestion</c> from <c>User</c>,
    /// and persists the both entities to the database.
    /// </summary>
    /// <param name="suggestion"></param>
    /// <param name="user"></param>
    /// <param name="votingUserId"></param>
    /// <returns>A <c>bool</c> based on upvote.</returns>
    public async Task<bool> Vote(Suggestion suggestion, User user, string votingUserId)
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

        await _suggestRepo.UpdateVote(suggestion, user);

        return isUpvote;
    }
}