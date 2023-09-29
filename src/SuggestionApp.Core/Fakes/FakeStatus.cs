namespace SuggestionApp.Core.Fakes;

public class FakeStatus
{
    public readonly static IReadOnlyList<Status> Statuses = new List<Status>
    {        
        new() 
        {
            Id = "1",
            Name = "Approved",
            Description = "The suggestion was approved!"
        },
        new() 
        {
            Id = "2",
            Name = "Archived",
            Description = "The suggestion has been archived."
        },        
        new() 
        {
            Id = "3",
            Name = "Completed",
            Description = "The suggestion was approved and it's corresponding content was created."
        },      
        new() 
        {
            Id = "3",
            Name = "Rejected",
            Description = "The suggestion was rejected."
        },
        new() 
        {
            Id = "4",
            Name = "Upcoming",
            Description = "The suggestion was approved and it'll be release soon."
        },          
        new() 
        {
            Id = "5",
            Name = "Waiting For Approval",
            Description = "The suggestion was created and waiting approval by the admin."
        },
        new() 
        {
            Id = "6",
            Name = "Watching",
            Description = "The suggestion has gained interest. We're watching it!"
        }
    };
}