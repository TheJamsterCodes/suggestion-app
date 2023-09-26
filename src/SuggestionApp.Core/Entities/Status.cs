namespace SuggestionApp.Core.Entities;

/// <summary>
/// <c>Status</c> model illustrates the status of a <c>Suggestion</c>.
/// </summary>
public class Status
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Description { get; set; }
    public string Name { get; set; }
}