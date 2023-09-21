namespace SuggestionApp.Core.Models;

public sealed class BasicUser
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; }  
    public string DisplayName { get; }

    public BasicUser() { }

    public BasicUser(User user)
    {
        Id = user.Id;
        DisplayName = user.DisplayName;    
    }
}