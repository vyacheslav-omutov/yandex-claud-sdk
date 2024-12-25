using System.Text.Json.Serialization;

namespace Yandex.ID.Responses;

public sealed class YandexTokenResponse
{
    /// <summary>
    /// Type of token issued. Always takes the bearer value.
    /// See more: https://yandex.ru/dev/id/doc/en/codes/code-url
    /// </summary>
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; } = default!;
    
    /// <summary>
    /// An OAuth token with the requested rights or with the rights specified when registering the app.
    /// See more: https://yandex.ru/dev/id/doc/en/codes/code-url
    /// </summary>
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = default!;
    
    /// <summary>
    /// Token lifetime in seconds.
    /// See more: https://yandex.ru/dev/id/doc/en/codes/code-url
    /// </summary>
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }
    
    /// <summary>
    /// A token that can be used to extend the lifetime of the corresponding OAuth token. The lifetime of the refresh
    /// token is the same as that of the OAuth token.
    /// See more: https://yandex.ru/dev/id/doc/en/codes/code-url
    /// </summary>
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; } = default!;
    
    /// <summary>
    /// Permissions requested by the developer or specified during app registration. The scope field is optional and is
    /// returned if OAuth provided a token with fewer permissions than was requested.
    /// See more: https://yandex.ru/dev/id/doc/en/codes/code-url
    /// </summary>
    [JsonPropertyName("scope")]
    public string Scope { get; set; } = default!;
}