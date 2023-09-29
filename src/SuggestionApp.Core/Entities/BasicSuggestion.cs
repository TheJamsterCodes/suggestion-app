namespace SuggestionApp.Core.Entities;

/// <summary>
/// <c>BasicSuggestion</c> value object
/// </summary>
public sealed class BasicSuggestion : BaseEntity
{
    [BsonElement("title")]
    public string Title { get; }

    public BasicSuggestion() { }

    public BasicSuggestion(Suggestion suggestion)
    {
        Id = suggestion.Id;
        Title = suggestion.Title;
    }
}