namespace SuggestionApp.Core.Interfaces;

public interface IAdminService
{
    Task<bool> ApproveForRelease(Suggestion suggestion);
    Task<bool> Reject(Suggestion suggestion);
    Task<bool> UpdateAdminNotes(Suggestion suggestion, string adminNotes);
    Task<bool> UpdateDescription(Suggestion suggestion, string description);
    Task<bool> UpdateTitle(Suggestion suggestion, string title);
    Task<bool> UpdateStatus(Suggestion suggestion, Status status);
}