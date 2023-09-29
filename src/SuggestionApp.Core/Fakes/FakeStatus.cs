namespace SuggestionApp.Core.Fakes;

public class FakeStatus : BaseEntity
{
    public readonly static IReadOnlyList<Status> Statuses = new List<Status>
    {        
        new() 
        {
            Name = "Approved",
            Description = "The suggestion was approved!"
        },
        new() 
        {
            Name = "Archived",
            Description = "The suggestion has been archived."
        },        
        new() 
        {
            Name = "Completed",
            Description = "The suggestion was approved and it's corresponding content was created."
        },      
        new() 
        {
            Name = "Rejected",
            Description = "The suggestion was rejected."
        },
        new() 
        {
            Name = "Upcoming",
            Description = "The suggestion was approved and it'll be release soon."
        },          
        new() 
        {
            Name = "Waiting For Approval",
            Description = "The suggestion was created and waiting approval by the admin."
        },
        new() 
        {
            Name = "Watching",
            Description = "The suggestion has gained interest. We're watching it!"
        }
    };
}