namespace SuggestionApp.Core.Entities;

/// <summary>
/// <c>Status</c> model illustrates the status of a <c>Suggestion</c>.
/// </summary>
public class Status : BaseEntity
{
    [BsonElement("description")]
    public string Description { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }
}