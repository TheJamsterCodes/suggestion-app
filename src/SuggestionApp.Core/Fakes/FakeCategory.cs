namespace SuggestionApp.Core.Fakes;

public class FakeCategory : BaseEntity
{
    public readonly static IReadOnlyList<Category> Categories = new List<Category>
    {
        new()
        {
            Name = "Courses",
            Description = "Fully paid courses"
        },
        new()
        {
            Name = "Dev Questions",
            Description = "Advice on being a developer"
        },
        new()
        {
            Name = "In-depth tutorials",
            Description = "A deep-dive video on how to use a topic"
        },
        new()
        {
            Name = "Quick byte",
            Description = "A quick \"How do I do this?\" video"
        },
        new()
        {
            Name = "Blog post",
            Description = "A short blog post"
        },
        new()
        {
            Name = "Other",
            Description = "Not sure what category the content belongs to"
        }        
    };
}