using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

using SuggestionApp.Application;
using SuggestionApp.Repository;

namespace SuggestionApp.UI;

public static class ServiceRegistration 
{
    public static void ConfigureServices(this WebApplicationBuilder builder) 
    {                
        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor().AddMicrosoftIdentityConsentHandler();
        builder.Services.AddMemoryCache();
        builder.Services.AddControllersWithViews().AddMicrosoftIdentityUI();

        builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                        .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAdB2C"));

        builder.Services.AddAuthorization(c => c.AddPolicy("Admin", cp => cp.RequireClaim("jobTitle", "Admin")));

        builder.Services.AddSingleton<IDbConnection, MongoDbConnection>();
        builder.Services.AddSingleton<IBaseRepository<Category>, CategoryRepository>();
        //builder.Services.AddSingleton<IBaseRepository<Category>, MockCategoryRepository>();
        builder.Services.AddSingleton<IBaseRepository<Status>, StatusRepository>();
        //builder.Services.AddSingleton<IBaseRepository<Status>, MockStatusRepository>();
        builder.Services.AddSingleton<IBaseRepository<Suggestion>, SuggestionRepository>();
        builder.Services.AddSingleton<ISuggestionRepository, SuggestionRepository>();
        builder.Services.AddSingleton<IBaseRepository<User>, UserRepository>();

        builder.Services.AddSingleton<ICategoryService, CategoryService>();
        builder.Services.AddSingleton<IStatusService, StatusService>();
        builder.Services.AddSingleton<ISuggestionService, SuggestionService>();
        builder.Services.AddSingleton<IUserService, UserService>();
    }
}