using System.Text.Json.Serialization;

namespace Yandex.ID.Requests;

public class YandexTokenRequest(
    string grantType, 
    string code)
{
    /// <summary>
    /// The method used to request the OAuth token. If you use a confirmation code, set the value to authorization_code.
    /// See more: https://yandex.ru/dev/id/doc/en/codes/code-url
    /// </summary>
    [JsonPropertyName("grant_type")]
    public string GrantType { get; set; } = grantType;
    
    /// <summary>
    /// Confirmation code from Yandex OAuth.
    /// See more: https://yandex.ru/dev/id/doc/en/codes/code-url
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; } = code;
}