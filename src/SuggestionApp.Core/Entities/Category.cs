namespace SuggestionApp.Core.Entities;

/// <summary>
/// A <c>Category</c> model describes the category of a <c>Suggestion</c>.
/// </summary>
public class Category : BaseEntity
{
    [BsonElement("description")]
    public string Description { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }
}