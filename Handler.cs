using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace School42.OAuth;

internal class Handler(IOptionsMonitor<Options> options, ILoggerFactory logger, UrlEncoder encoder) : OAuthHandler<Options>(options, logger, encoder)
{
    protected override async Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity,
        AuthenticationProperties properties, OAuthTokenResponse tokens)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, Options.UserInformationEndpoint);
        request.Headers.Add("Authorization", $"Bearer {tokens.AccessToken}");
        request.Headers.Add("User-Agent", "Delegates42");
        
        var response = await Backchannel.SendAsync(request, Context.RequestAborted);
        response.EnsureSuccessStatusCode();
        
        var json = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        var context = new OAuthCreatingTicketContext(new ClaimsPrincipal(identity), properties, Context, Scheme, Options, Backchannel, tokens, json.RootElement);
        context.RunClaimActions();
        
        await Options.Events.CreatingTicket(context);
        return context.Principal != null ? new AuthenticationTicket(context.Principal, context.Properties, Scheme.Name) : null;
    }
}