using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace School42.OAuth;

public static class Extensions
{
    public static AuthenticationBuilder AddSchool42(this AuthenticationBuilder builder)
        => builder.AddSchool42(Defaults.AuthenticationScheme, _ => { });

    public static AuthenticationBuilder AddSchool42(this AuthenticationBuilder builder, Action<Options> configureOptions)
        => builder.AddSchool42(Defaults.AuthenticationScheme, configureOptions);

    private static AuthenticationBuilder AddSchool42(this AuthenticationBuilder builder, string authenticationScheme, Action<Options> configureOptions)
        => builder.AddSchool42(authenticationScheme, Defaults.DisplayName, configureOptions);

    private static AuthenticationBuilder AddSchool42(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<Options> configureOptions)
        => builder.AddOAuth<Options, Handler>(authenticationScheme, displayName, configureOptions);
}