namespace SuggestionApp.Core.Models;

/// <summary>
/// <c>User</c> model
/// </summary>
public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }    

    /// <summary>
    /// A list of suggestions that the user has authored.
    /// </summary>
    public List<BasicSuggestion> AuthoredSuggestions { get; set; }

    /// <summary>
    /// The display name of the user as it appears on the application UI.
    /// </summary>
    public string DisplayName { get; set; }
    
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    /// <summary>
    /// The Azure Active Directory B2C object id.
    /// </summary>
    public string ObjectIdentifier { get; set; }

    /// <summary>
    /// A list of suggestions that the user voted on.
    /// </summary>
    public List<BasicSuggestion> VotedSuggestions { get; set; }
}