using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace SuggestionApp.UI.Pages;

public partial class Index
{
    private IEnumerable<Category> _categories;
    private bool _isSortedByNew = true;
    private string _searchText = string.Empty;
    private string _selectedCategory = "All";
    private string _selectedStatus = "All";
    private IEnumerable<Status> _statuses;
    private IEnumerable<Suggestion> _suggestions;

    protected async override Task OnInitializedAsync()
    {
        _categories = await category.Get();
        _statuses = await status.Get();
    }

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await LoadFilterState();
            await FilterSuggestions();
            StateHasChanged();
        }
    }    

    private async Task FilterSuggestions()
    {
        IEnumerable<Suggestion> suggestions = await suggestion.GetApprovedForRelease();

        if (_selectedCategory != "All")
        {
            suggestions = suggestions.Where(s => s.Category?.Name == _selectedCategory);
        }

        if (_selectedStatus != "All")
        {
            suggestions = suggestions.Where(s => s.Status?.Name == _selectedStatus);
        }

        if (string.IsNullOrWhiteSpace(_searchText))
        {
            suggestions = suggestions.Where(
                s => s.Title.Contains(_searchText, StringComparison.InvariantCultureIgnoreCase)
                || s.Description.Contains(_searchText, StringComparison.InvariantCultureIgnoreCase)
            );
        }

        suggestions = _isSortedByNew
            ? suggestions.OrderByDescending(s => s.DateCreated)
            : suggestions.OrderByDescending(s => s.Votes).ThenByDescending(s => s.DateCreated);

        _suggestions = suggestions;

        await SaveFilterState();
    }

    private async Task LoadFilterState()
    {
        ProtectedBrowserStorageResult<string> stringResult;
        ProtectedBrowserStorageResult<bool> boolResult;

        stringResult = await sessionStorage.GetAsync<string>(nameof(_selectedCategory));
        _selectedCategory = stringResult.Success ? stringResult.Value : "All";

        stringResult = await sessionStorage.GetAsync<string>(nameof(_selectedStatus));
        _selectedStatus = stringResult.Success ? stringResult.Value : "All";

        stringResult = await sessionStorage.GetAsync<string>(nameof(_searchText));
        _searchText = stringResult.Success ? stringResult.Value : string.Empty;     

        boolResult = await sessionStorage.GetAsync<bool>(nameof(_isSortedByNew));
        _isSortedByNew = !boolResult.Success || boolResult.Value;   
    }

    private async Task OnCategoryClick(string category = "All")
    {
        _selectedCategory = category;
        await FilterSuggestions();
    }

    private async Task OnSearchInput(string searchInput)
    {
        _searchText = searchInput;
        await FilterSuggestions();
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

    private void OpenSuggestionDetails(Suggestion suggestion)
    {
        navManager.NavigateTo($"/Details/{suggestion.Id}");
    }

    private async Task SaveFilterState()
    {
        await sessionStorage.SetAsync(nameof(_selectedCategory), _selectedCategory);
        await sessionStorage.SetAsync(nameof(_selectedStatus), _selectedStatus);
        await sessionStorage.SetAsync(nameof(_searchText), _searchText);
        await sessionStorage.SetAsync(nameof(_isSortedByNew), _isSortedByNew);
    }  

    private string SetVoteText_Top(Suggestion suggestion) => suggestion.Votes.Count > 0 ? suggestion.Votes.Count.ToString("00") : "Click to ";

    private string SetVoteText_Bottom(Suggestion suggestion) => suggestion.Votes.Count > 1 ? "Votes" : "Vote";
}