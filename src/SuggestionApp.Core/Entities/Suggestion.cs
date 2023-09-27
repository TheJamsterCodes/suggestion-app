namespace SuggestionApp.Core.Entities;

/// <summary>
/// <c>Suggestion</c> model
/// </summary>
public class Suggestion
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string AdminNotes { get; set; }
    public Author Author { get; set; }
    public Category Category { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public DateTime DateUpdated { get; set; }
    public string Description { get; set; }
    public bool IsApprovedForRelease { get; set; } = false;
    public bool IsArchived { get; set; } = false;
    public bool IsRejected { get; set; } = false;
    public Status Status { get; set; }
    public string Title { get; set; }

    public HashSet<string> Votes => _votes;
    private readonly HashSet<string> _votes = new();
}