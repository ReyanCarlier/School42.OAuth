using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;

namespace School42.OAuth;

public class Options : OAuthOptions
{
    public Options()
    {
        CallbackPath = new PathString("/signin-42");
        AuthorizationEndpoint = Defaults.AuthorizationEndpoint;
        TokenEndpoint = Defaults.TokenEndpoint;
        UserInformationEndpoint = Defaults.UserInformationEndpoint;
        Scope.Add("public");
        // Scope.Add("projects");
        // Scope.Add("profile");
        // Scope.Add("elearning");
        // Scope.Add("tig");
        // Scope.Add("forum");
        ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
        ClaimActions.MapJsonKey(ClaimTypes.Name, "login");
        ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
        ClaimActions.MapJsonKey("urn:42:displayname", "displayname");
        ClaimActions.MapJsonKey("urn:42:staff", "staff?");
        ClaimActions.MapJsonKey("urn:42:correction_point", "correction_point");
        
    }
}