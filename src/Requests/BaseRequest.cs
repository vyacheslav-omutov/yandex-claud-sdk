using System.Text.Json.Serialization;
using Yandex.ID.Enums;

namespace Yandex.ID.Requests;

public class BaseRequest(ResponseType responseType, string clientId)
{
    /// <summary>
    /// The required response. Should be set to code when requesting a confirmation code.
    /// See more: https://yandex.ru/dev/id/doc/en/codes/code-url
    /// </summary>
    [JsonPropertyName("response_type")]
    public ResponseType ResponseType { get; set; } = responseType;
    
    /// <summary>
    /// The app ID. It can be found in the app properties. To open them, go to Yandex OAuth and select the app name.
    /// See more: https://yandex.ru/dev/id/doc/en/codes/code-url
    /// </summary>
    [JsonPropertyName("client_id")]
    public string ClientId { get; set; } = clientId;
}