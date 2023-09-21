namespace SuggestionApp.UI;

public static class ServiceRegistration 
{
    public static void ConfigureServices(this WebApplicationBuilder builder) 
    {
        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
    }
}