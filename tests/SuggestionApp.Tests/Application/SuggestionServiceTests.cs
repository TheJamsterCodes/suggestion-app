namespace SuggestionApp.Tests.Application;

[TestFixture]
public class SuggestionServiceTests
{
    private readonly ISuggestionRepository _mockSuggestRepo = Substitute.For<ISuggestionRepository>();
    private SuggestionService _suggestion;

    [SetUp]
    public void Setup()
    {
        _suggestion = new(_mockSuggestRepo);
    }

    [Test]
    public void AuthoredSuggestion_UserHasABasicSuggestion()
    {
        var user = new User { Id = "12345", DisplayName = "elJamster" };

        var suggestion = new Suggestion
        {
            Id = "A12345",
            Author = new Author(user),
            Title = "My first suggestion"
        };

        var actual = new BasicSuggestion(suggestion);

        _suggestion.AuthorSuggestion(suggestion, user);

        Assert.That(user.AuthoredSuggestions.Any(s => s.Id == actual.Id));
        _mockSuggestRepo.Received().CreateWithAuthor(Arg.Is(suggestion), Arg.Is(user));
    }
}