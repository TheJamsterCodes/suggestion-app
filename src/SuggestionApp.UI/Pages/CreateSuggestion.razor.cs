namespace SuggestionApp.UI.Pages;
public partial class CreateSuggestion
{
    private IEnumerable<Category> _categories;
    private Suggestion _suggestionInput = new() { Category = new Category() };
    private User _user;
    protected async override Task OnInitializedAsync()
    {
        _categories = await categorySvc.Get();        
        _user = await authProvider.AuthenticateUser(userSvc);
    }

    private void OnCloseCreateSuggestion()
    {
        navManager.NavigateTo("/");
    }

    private async Task Submit()
    {
        var newSuggestion = new Suggestion
        {
            Author = new Author(_user),
            Category = _categories.First(c => c.Id == _suggestionInput.Category.Id),
            DateUpdated = DateTime.UtcNow,
            Description = _suggestionInput.Description,
            Title = _suggestionInput.Title
        };
        await suggestionSvc.AuthorSuggestion(newSuggestion, _user);
        _suggestionInput = new();
    }
}