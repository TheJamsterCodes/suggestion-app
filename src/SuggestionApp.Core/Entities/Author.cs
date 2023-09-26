namespace SuggestionApp.Core.Entities;

public sealed class Author
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; }  
    public string DisplayName { get; }

    public Author() { }

    public Author(User user)
    {
        Id = user.Id;
        DisplayName = user.DisplayName;    
    }
}