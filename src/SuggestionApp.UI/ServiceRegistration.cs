using SuggestionApp.Core.Entities;
using SuggestionApp.Core.Interfaces;
using SuggestionApp.Repository;

namespace SuggestionApp.UI;

public static class ServiceRegistration 
{
    public static void ConfigureServices(this WebApplicationBuilder builder) 
    {
        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddMemoryCache();

        builder.Services.AddSingleton<IDbConnection, MongoDbConnection>();
        builder.Services.AddSingleton<IBaseRepository<Category>, CategoryRepository>();
        builder.Services.AddSingleton<IBaseRepository<Status>, StatusRepository>();
        builder.Services.AddSingleton<IBaseRepository<Suggestion>, SuggestionRepository>();
        builder.Services.AddSingleton<ISuggestionRepository, SuggestionRepository>();
        builder.Services.AddSingleton<IBaseRepository<User>, UserRepository>();
    }
}