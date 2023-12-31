namespace SuggestionApp.Tests.Application;

[TestFixture]
public class SuggestionServiceTests
{
    private readonly IBaseRepository<Suggestion> _mockBaseRepo = Substitute.For<IBaseRepository<Suggestion>>();
    private readonly ISuggestionRepository _mockSuggestRepo = Substitute.For<ISuggestionRepository>();
    private SuggestionService _suggestion;

    [SetUp]
    public void Setup()
    {
        _suggestion = new(_mockBaseRepo, _mockSuggestRepo);
    }

    [Test]
    public async Task AuthoredSuggestion_UserHasABasicSuggestion()
    {
        var user = new User { Id = "12345", DisplayName = "elJamster" };

        var suggestion = new Suggestion
        {
            Id = "A12345",
            Author = new Author(user),
            Title = "My first suggestion"
        };

        var actual = new BasicSuggestion(suggestion);

        await _suggestion.AuthorSuggestion(suggestion, user);

        Assert.That(user.AuthoredSuggestions.Any(s => s.Id == actual.Id));
        await _mockSuggestRepo.Received().CreateWithAuthor(Arg.Is(suggestion), Arg.Is(user));
    }

    [Test]
    public async Task Vote_IsUpvote_True()
    {
        bool expected = true;
        var user = new User { Id = "12345", DisplayName = "elJamster" };

        var suggestion = new Suggestion
        {
            Id = "A12345",
            Author = new Author(user),
            Title = "Just a suggestion",
        };        
        
        string votingUserId = "B123456"; 

        bool actual = await _suggestion.Vote(suggestion, user, votingUserId);

        Assert.That(actual, Is.EqualTo(expected));
        await _mockSuggestRepo.Received().UpdateVote(Arg.Is(suggestion), Arg.Is(user));      
    }

    [Test]
    public async Task Vote_IsUpvote_False()
    {
        bool expected = false;
        var user = new User { Id = "12345", DisplayName = "elJamster" };

        var suggestion = new Suggestion
        {
            Id = "A12345",
            Author = new Author(user),
            Title = "Just a suggestion",
        };        
        
        string votingUserId = "B123456"; 
        suggestion.Votes.Add(votingUserId);
        user.VotedSuggestions.Add(new BasicSuggestion(suggestion));

        bool actual = await _suggestion.Vote(suggestion, user, votingUserId);

        Assert.That(actual, Is.EqualTo(expected));
        await _mockSuggestRepo.Received().UpdateVote(Arg.Is(suggestion), Arg.Is(user));           
    }

    [Test]
    public async Task Vote_BasicSuggestion_Added()
    {
        bool expected = true;
        var user = new User { Id = "12345", DisplayName = "elJamster" };

        var suggestion = new Suggestion
        {
            Id = "A12345",
            Author = new Author(user),
            Title = "Just a suggestion",
        };      

        string votingUserId = "B123456";  
        
        _ = await _suggestion.Vote(suggestion, user, votingUserId);  
        bool actual = user.VotedSuggestions.Any(vs => vs.Id == suggestion.Id);

        Assert.That(actual, Is.EqualTo(expected));
        await _mockSuggestRepo.Received().UpdateVote(Arg.Is(suggestion), Arg.Is(user));
    }

    [Test]
    public async Task Vote_BasicSuggestion_Removed()
    {
        bool expected = false;
        var user = new User { Id = "12345", DisplayName = "elJamster" };

        var suggestion = new Suggestion
        {
            Id = "A12345",
            Author = new Author(user),
            Title = "Just a suggestion",
        };      

        string votingUserId = "B123456";  
        suggestion.Votes.Add(votingUserId);
        user.VotedSuggestions.Add(new BasicSuggestion(suggestion));        
        
        _ = await _suggestion.Vote(suggestion, user, votingUserId);   
        bool actual = user.VotedSuggestions.Any(vs => vs.Id == suggestion.Id);

        Assert.That(actual, Is.EqualTo(expected));
        await _mockSuggestRepo.Received().UpdateVote(Arg.Is(suggestion), Arg.Is(user));
    }    
}