namespace SuggestionApp.Core.Interfaces;

public interface IStatusService
{
    void Create(Status status);
    void Create(IList<Status> statuses);
    Task<Status> Get(string id);
    Task<IEnumerable<Status>> Get();    
}