namespace SuggestionApp.Core.Entities;

/// <summary>
/// <c>User</c> model
/// </summary>
public class User : BaseEntity
{
    /// <summary>
    /// A collection of suggestions that the user has authored.
    /// </summary>
    [BsonElement("authoredSuggestions")]
    public IList<BasicSuggestion> AuthoredSuggestions => _authoredSuggestions;
    private readonly List<BasicSuggestion> _authoredSuggestions = new();

    /// <summary>
    /// The display name of the user as it appears on the application UI.
    /// </summary>
    [BsonElement("displayName")]
    public string DisplayName { get; set; }
    
    [BsonElement("email")]
    public string Email { get; set; }
    
    [BsonElement("firstName")]
    public string FirstName { get; set; }
    
    [BsonElement("lastName")]
    public string LastName { get; set; }

    /// <summary>
    /// The Azure Active Directory B2C object id.
    /// </summary>
    [BsonElement("objectIdentifier")]
    public string ObjectIdentifier { get; set; }

    /// <summary>
    /// A collection of suggestions that the user voted on.
    /// </summary>
    [BsonElement("votedSuggestions")]
    public IList<BasicSuggestion> VotedSuggestions => _votedSuggestions;
    private readonly List<BasicSuggestion> _votedSuggestions = new();
}