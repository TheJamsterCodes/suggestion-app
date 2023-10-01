using Microsoft.AspNetCore.Rewrite;

using SuggestionApp.UI;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// Authentication and Authorization with redirects
app.UseAuthentication();
app.UseAuthorization();
app.UseRewriter(new RewriteOptions().Add(contextRule =>
    { 
        if (contextRule.HttpContext.Request.Path == "MicrosoftIdentity/Account/SignedOut")
        {
            contextRule.HttpContext.Response.Redirect("/");
        }
    }
));

// Mappings
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
