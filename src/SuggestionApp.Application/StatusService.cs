
namespace SuggestionApp.Application;

public class StatusService : IStatusService
{
    private readonly IBaseRepository<Status> _statusRepo;

    public StatusService(IBaseRepository<Status> statusRepo) => _statusRepo = statusRepo;
    
    public void Create(Status status)
    {
        _statusRepo.Create(status);
    }

    public void Create(IList<Status> statuses)
    {
        _statusRepo.CreateMany(statuses);
    }

    public async Task<Status> Get(string id) => await _statusRepo.Read(id);

    public async Task<IEnumerable<Status>> Get() => await _statusRepo.ReadMany();
}
