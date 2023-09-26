namespace SuggestionApp.Repository;

public class VoteRepository
{
    private readonly IDbConnection _db;
    private readonly IMongoClient _client;

    public VoteRepository(IDbConnection db)
    {
        _db = db;
        _client = db.Client;
    }

    // public async Task<bool> Update(Suggestion suggestion)
    // {
    //     using var session = _client.StartSession();

    //     session.WithTransactionAsync(
    //         (s, ct) => 
    //         {

    //         });

    // }
}