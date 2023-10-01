using Microsoft.AspNetCore.Components.Authorization;

namespace SuggestionApp.UI.Helpers;

public static class Authentication
{
    public static async Task<User> AuthenticateUser(this AuthenticationStateProvider provider, IUserService user)
    {
        var authState = await provider.GetAuthenticationStateAsync();
        string objectId = authState.User.Claims.FirstOrDefault(c => c.Type.Contains("objectidentifier"))?.Value;
        return await user.GetByAuth(objectId);
    }
}
