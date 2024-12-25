using System.Text.Json.Serialization;

namespace Yandex.ID.Responses.Errors;

public sealed class YandexErrorResponse
{
    /// <summary>
    /// Error code
    /// See more: https://yandex.ru/dev/id/doc/en/codes/code-url
    /// </summary>
    [JsonPropertyName("error")]
    public string Error { get; set; } = default!;
    
    /// <summary>
    /// Error description
    /// See more: https://yandex.ru/dev/id/doc/en/codes/code-url
    /// </summary>
    [JsonPropertyName("error_description")]
    public string ErrorDescription { get; set; } = default!;
    
    /// <summary>
    /// The status bar that Yandex OAuth returns without changes. The maximum allowed string length is 1024 characters.
    /// Can be used, for example, to protect against CSRF attacks or identify the user the token is requested for.
    /// See more: https://yandex.ru/dev/id/doc/en/codes/code-url
    /// </summary>
    [JsonPropertyName("state")]
    public string State { get; set; } = default!;
}