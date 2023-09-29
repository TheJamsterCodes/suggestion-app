namespace SuggestionApp.Core.Entities;

public sealed class Author : BaseEntity
{
    [BsonElement("displayName")]
    public string DisplayName { get; }

    public Author() { }

    public Author(User user)
    {
        Id = user.Id;
        DisplayName = user.DisplayName;    
    }
}