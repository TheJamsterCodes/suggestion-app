namespace SuggestionApp.Core.Mocks;

public class MockCategory
{
    public readonly static IReadOnlyList<Category> Categories = new List<Category>
    {
        new()
        {
            Id = "1",
            Name = "Courses",
            Description = "Fully paid courses"
        },
        new()
        {
            Id = "2",
            Name = "Dev Questions",
            Description = "Advice on being a developer"
        },
        new()
        {
            Id = "3",
            Name = "In-depth tutorials",
            Description = "A deep-dive video on how to use a topic"
        },
        new()
        {
            Id = "4",
            Name = "Quick byte",
            Description = "A quick \"How do I do this?\" video"
        },
        new()
        {
            Id = "5",
            Name = "Blog post",
            Description = "A short blog post"
        },
        new()
        {
            Id = "6",
            Name = "Other",
            Description = "Not sure what category the content belongs to"
        }        
    };
}