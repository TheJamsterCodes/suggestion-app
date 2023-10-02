namespace SuggestionApp.Core.Fakes;

public class FakeUser
{
    public readonly static IReadOnlyList<User> Users = new List<User>
    {
        new()
        {
            DisplayName = "sampleJamster",
            Email = "jamster@email.com",
            FirstName = "Sample First",
            LastName = "Sample Last",
            ObjectIdentifier = "ala963"
        }
    };
}
