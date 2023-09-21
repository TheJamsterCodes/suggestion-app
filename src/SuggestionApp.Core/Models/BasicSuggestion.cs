namespace SuggestionApp.Core.Models;

/// <summary>
/// <c>BasicSuggestion</c> value object
/// </summary>
public sealed class BasicSuggestion
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; }
    public string Title { get; }

    public BasicSuggestion() { }

    public BasicSuggestion(Suggestion suggestion)
    {
        Id = suggestion.Id;
        Title = suggestion.Title;
    }
}