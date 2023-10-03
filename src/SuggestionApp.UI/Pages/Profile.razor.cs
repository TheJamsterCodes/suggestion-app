namespace SuggestionApp.UI.Pages;

public partial class Profile
{
    private bool _isSortedByNew = true;
    private string _selectedStatus = "All";
    private IEnumerable<Status> _statuses;
    private IEnumerable<Suggestion> _suggestions;
    private User _user;
    
    protected async override Task OnInitializedAsync()
    {
        _statuses = await statusSvc.Get();
        _user = await authProvider.AuthenticateUser(userSvc);
    }

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await LoadFilterState();
            await FilterSuggestions();
            base.StateHasChanged();
        }
    }

    private async Task FilterSuggestions()
    {
        IEnumerable<Suggestion> suggestions = await suggestionSvc.GetByUserId(_user.Id);
        if (_selectedStatus != "All")
        {
            suggestions = suggestions.Where(s => s.Status?.Name == _selectedStatus);
        }

        suggestions = _isSortedByNew ? suggestions.OrderByDescending(s => s.DateCreated) : suggestions.OrderByDescending(s => s.Votes).ThenByDescending(s => s.DateCreated);
        _suggestions = suggestions;
        await SaveFilterState();
    }

    private async Task LoadFilterState()
    {
        ProtectedBrowserStorageResult<string> stringResult;
        ProtectedBrowserStorageResult<bool> boolResult;
        stringResult = await sessionStorage.GetAsync<string>(nameof(_selectedStatus));
        _selectedStatus = stringResult.Success ? stringResult.Value : "All";
        boolResult = await sessionStorage.GetAsync<bool>(nameof(_isSortedByNew));
        _isSortedByNew = !boolResult.Success || boolResult.Value;
    }

    private void OnCloseProfile()
    {
        navManager.NavigateTo("/");
    }

    private async Task OnSortByNew(bool isSortedByNew)
    {
        _isSortedByNew = isSortedByNew;
        await FilterSuggestions();
    }

    private async Task OnStatusClick(string status = "All")
    {
        _selectedStatus = status;
        await FilterSuggestions();
    }

    private async Task SaveFilterState()
    {
        await sessionStorage.SetAsync(nameof(_selectedStatus), _selectedStatus);
        await sessionStorage.SetAsync(nameof(_isSortedByNew), _isSortedByNew);
    }
}