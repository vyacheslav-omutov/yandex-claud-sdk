using System.Text.Json.Serialization;

namespace Yandex.ID.Responses;

public sealed class YandexCodeResponse
{
    /// <summary>
    /// Confirmation code that can be exchanged for an OAuth token.
    /// The code's lifetime is 10 minutes. When it expires, you need to request a new code.
    /// See more: https://yandex.ru/dev/id/doc/en/codes/code-url
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; } = default!;
    
    /// <summary>
    /// The status bar that Yandex OAuth returns without changes. The maximum allowed string length is 1024 characters.
    /// Can be used, for example, to protect against CSRF attacks or identify the user the token is requested for.
    /// See more: https://yandex.ru/dev/id/doc/en/codes/code-url
    /// </summary>
    [JsonPropertyName("state")]
    public string State { get; set; } = default!;
}