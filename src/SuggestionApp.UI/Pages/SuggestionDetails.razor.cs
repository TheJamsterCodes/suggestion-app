namespace SuggestionApp.UI.Pages;

public partial class SuggestionDetails
{
    [Parameter]
    public string Id { get; set; }

    private Suggestion _suggestion;
    protected async override Task OnInitializedAsync()
    {
        _suggestion = await suggestionSvc.Get(Id);
    }

    private void OnCloseDetails()
    {
        navManager.NavigateTo("/");
    }

    private string SetVoteText_Top() => _suggestion.Votes.Count > 0 ? _suggestion.Votes.Count.ToString("00") : "Click to ";
    private string SetVoteText_Bottom() => _suggestion.Votes.Count > 1 ? "Votes" : "Vote";
}