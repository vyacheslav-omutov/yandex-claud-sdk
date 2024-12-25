using Yandex.ID.Requests.Authorization;
using Yandex.ID.Responses;

namespace Yandex.ID.Services.Authorization;

public interface IYandexAuthorizationService
{
    /// <summary>
    /// If you can set up automatic extraction of information from URLs in your app, extract the confirmation code from
    /// the redirect URL.
    /// See more: https://yandex.ru/dev/id/doc/en/codes/code-url
    /// </summary>
    /// <returns>Url for request a confirmation code.</returns>
    Task<string> GetUrlForRequestCodeAsync(YandexAuthorizeRequest? request = null);
    
    /// <summary>
    /// Exchange the confirmation code for an OAuth token.
    /// </summary>
    /// <param name="code">confirmation code from Yandex OAuth.</param>
    /// <returns></returns>
    Task<YandexTokenResponse> GetTokenAsync(string code);
}