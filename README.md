# Yandex.Cloud.SDK

<img align="right" width="80px" height="80px" src="img/logo.png">

Yandex.Cloud.SDK is authoring library [API Yandex Claud](https://yandex.cloud/en/docs) services for .NET Core.

## What is Yandex Cloud?

> **_Yandex Cloud_**
> _- is a platform that provides businesses with access to Yandex cloud technologies.
> It can store and sort data, pay and detail expenses, create remote workstations, manage network connections, etc._

## Yandex ID

[Yandex ID](https://yandex.ru/dev/id/doc/en/) — is a [single account to access all Yandex services](https://yandex.com/support/id/index.html). API Yandex ID allows you to authorize users on your
website or mobile app using their Yandex account and via the [OAuth 2.0 protocol](https://yandex.ru/dev/id/doc/en/concepts/ya-oauth-intro).

## Usage API Yandex ID

### Register your app

To get OAuth tokens for managing access to Yandex users' data, the developer needs to register their app in [Yandex OAuth](https://oauth.yandex.com/).
After registration, the app will be available for editing in the [Yandex OAuth control panel](https://yandex.ru/dev/id/doc/en/oauth-cabinet).

### Request an OAuth token in exchange for a confirmation code

Add [Yandex ID](https://yandex.ru/dev/id/doc/en/oauth-cabinet) to service collection:

```c#
builder.Services.AddYandexId(optionsBuilder =>
{
    optionsBuilder.AddYandexApplication(o =>
    {
        o.ClientId = "client_id";
        o.ClientSecret = "client_secret";
        o.RedirectUri = "redirect_uri";
    });
});
```

Get **IYandexAuthorizationService** from your service provider

```c#
var yandexAuthorizationService = serviceProvider.GetRequiredService<IYandexAuthorizationService>();
```

```c#
public interface IYandexAuthorizationService
{
    Task<string> GetUrlForRequestCodeAsync(YandexAuthorizeRequest? request = null);
    Task<YandexTokenResponse> GetTokenAsync(string code);
}
```

Get the url to Request an OAuth token in exchange for a confirmation code and return the user.

```c#
var url = await yandexAuthorizationService.GetUrlForRequestCodeAsync();
```

When the user grants the app access to their data, Yandex OAuth redirects them back to the app, to the address
specified in the Redirect URI field during app registration.

The confirmation code is returned in the redirect URL. To exchange the confirmation code for an OAuth token, the app has
to send a POST request.

The code's lifetime is 10 minutes. When it expires, you need to request a new code.

```c#
var tokenResponse = await yandexAuthorizationService.GetTokenAsync(code);
```

YandexTokenResponse model:
```c#
public sealed class YandexTokenResponse
{
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; } = default!;
    
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = default!;
    
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }
    
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; } = default!;
    
    [JsonPropertyName("scope")]
    public string Scope { get; set; } = default!;
}
```