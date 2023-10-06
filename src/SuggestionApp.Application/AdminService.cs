namespace SuggestionApp.Application;

public class AdminService : IAdminService
{
    private readonly ISuggestionRepository _suggestRepo;
    public AdminService(ISuggestionRepository suggestRepo) => _suggestRepo = suggestRepo;

    public async Task<bool> ApproveForRelease(Suggestion suggestion)
    {        
        suggestion.IsApprovedForRelease = true;
        return await _suggestRepo.AdminUpdate(suggestion, "IsApprovedForRelease");
    }

    public async Task<bool> Reject(Suggestion suggestion)
    {
        suggestion.IsRejected = true;
        return await _suggestRepo.AdminUpdate(suggestion, "IsRejected");
    }

    public async Task<bool> UpdateAdminNotes(Suggestion suggestion, string adminNotes)
    {
        suggestion.AdminNotes = adminNotes;
        return await _suggestRepo.AdminUpdate(suggestion, "AdminNotes");        
    }

    public async Task<bool> UpdateDescription(Suggestion suggestion, string description)
    {
        suggestion.Description = description;
        return await _suggestRepo.AdminUpdate(suggestion, "Description");        
    }

    public async Task<bool> UpdateStatus(Suggestion suggestion, Status status)
    {
        suggestion.Status = status;
        return await _suggestRepo.AdminUpdate(suggestion, "Status");        
    }

    public async Task<bool> UpdateTitle(Suggestion suggestion, string title)
    {
        suggestion.Title = title;
        return await _suggestRepo.AdminUpdate(suggestion, "Title");            
    }
}