namespace School42.OAuth;

public static class Defaults
{
    public const string AuthenticationScheme = "School42";
    public const string DisplayName = "School42";

    public const string AuthorizationEndpoint = "https://api.intra.42.fr/oauth/authorize";
    public const string TokenEndpoint = "https://api.intra.42.fr/oauth/token";
    public const string UserInformationEndpoint = "https://api.intra.42.fr/v2/me";
}