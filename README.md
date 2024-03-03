# School42.OAuth

This library provides an OAuth authentication handler specifically tailored for integrating School42's OAuth services with ASP.NET Core applications. It simplifies the process of adding School42 OAuth authentication capabilities to your web applications, allowing users to authenticate using their School42 credentials.

## Features

- Easy integration with ASP.NET Core applications.
- Customizable options to fit your application's authentication flow.
- Retrieves user information from School42's API after successful authentication.
- Supports additional scopes for extended access to the School42 API.

## Prerequisites

Before you begin, ensure you have the following:

- An ASP.NET Core project targeting .NET 8.0 or later.
- A registered application on School42's platform to obtain your client ID and client secret.
- Basic understanding of ASP.NET Core and OAuth authentication flows.

## Installation

To use the School42 OAuth authentication library in your project, you need to add the following package references to your `.csproj` file:

```xml
<ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Authentication.OAuth" Version="2.2.0" />
    <PackageReference Include="Microsoft.Extensions.Logging" Version="8.0.0" />
    <PackageReference Include="Microsoft.Extensions.Options" Version="8.0.2" />
    <FrameworkReference Include="Microsoft.AspNetCore.App" />
</ItemGroup>
```

After adding the package references, restore your project dependencies.

## Configuration

To configure the School42 OAuth authentication in your ASP.NET Core application, follow these steps:

1. In your `Startup.cs` or wherever you configure services, add the School42 OAuth service:

    ```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthentication(options =>
        {
            // Configure authentication schemes here
        })
        .AddSchool42(options =>
        {
            options.ClientId = "<YOUR_CLIENT_ID>";
            options.ClientSecret = "<YOUR_CLIENT_SECRET>";
            // Add additional scopes if needed
            options.Scope.Add("public");
            // options.Scope.Add("projects"); // Uncomment to request additional scopes
        });
    }
    ```

2. Ensure that your application uses authentication:

    ```csharp
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        // Other middleware configurations
    }
    ```

3. Update your application's callback path if necessary (default is `/signin-42`).

## Usage

Once configured, you can protect your routes using the `[Authorize]` attribute, and users will be redirected to School42's OAuth sign-in page when accessing protected resources. After successful authentication, users will be redirected back to your application.

## Customization

You can customize the behavior of the School42 OAuth handler by setting different properties on the `Options` object during configuration. For example, you can change the callback path, add additional scopes, or map different claims from the School42 user information response.

## Contributing

Contributions to the School42 OAuth authentication library are welcome. Please feel free to submit pull requests or create issues for bugs, questions, or new features.

---

Remember to replace `<YOUR_CLIENT_ID>` and `<YOUR_CLIENT_SECRET>` with your actual School42 OAuth credentials.
For more information on registering your application and obtaining these credentials, refer to [42's API guides](https://api.intra.42.fr/apidoc/guides/getting_started)
