namespace SuggestionApp.Core.Interfaces;

public interface ISuggestionService
{
    Task AuthorSuggestion(Suggestion suggestion, User user);
    Task<Suggestion> Get(string id);    
    Task<IEnumerable<Suggestion>> GetApprovedForRelease();
    Task<IEnumerable<Suggestion>> GetByUserId(string id);
    Task<IEnumerable<Suggestion>> GetWaitingForApproval();
    Task<bool> Vote(Suggestion suggestion, User user, string votingUserId);
}
