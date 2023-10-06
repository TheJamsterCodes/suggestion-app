namespace SuggestionApp.UI.Pages;
public partial class Administrator
{
    private string _adminNotes;
    private string _currentDescription;
    private string _currentTitle;
    private string _editedDescription;
    private string _editedTitle;
    private IList<Suggestion> _unreviewedSuggestions;
    private IList<Status> _statuses;

    protected async override Task OnInitializedAsync()
    {
        var suggestions = await suggestionSvc.GetWaitingForApproval();
        _unreviewedSuggestions = suggestions.ToList();

        var statuses = await statusSvc.Get();
        _statuses = statuses.ToList();
    }
    private async Task AddAdminNotes(Suggestion suggestion)
    {
        _ = await adminSvc.UpdateAdminNotes(suggestion, _adminNotes);
    }

    private async Task Approve(Suggestion suggestion)
    {
        bool isApproved = await adminSvc.ApproveForRelease(suggestion);
        if (isApproved) _unreviewedSuggestions.Remove(suggestion);
    }

    private async Task EditDescription(Suggestion suggestion)
    {
        _ = await adminSvc.UpdateDescription(suggestion, _editedDescription);
    }

    private async Task EditTitle(Suggestion suggestion)
    {
        _ = await adminSvc.UpdateTitle(suggestion, _editedTitle);
    }

    private async Task EditStatus(Suggestion suggestion, string statusName)
    {
        Status status = _statuses.First(s => s.Name == statusName);
        _ = await adminSvc.UpdateStatus(suggestion, status);
    }

    private void OnCloseAdmin() => navManager.NavigateTo("/");

    private async Task Reject(Suggestion suggestion)
    {
        bool isRejected = await adminSvc.Reject(suggestion);
        if (isRejected) _unreviewedSuggestions.Remove(suggestion);
    }
}