namespace SuggestionApp.Core.Entities;

/// <summary>
/// A <c>Category</c> model describes the category of a <c>Suggestion</c>.
/// </summary>
public class Category
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Description { get; set; }
    public string Name { get; set; }
}
