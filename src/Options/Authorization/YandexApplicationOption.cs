namespace Yandex.ID.Options.Authorization;

public class YandexApplicationOption
{
    /// <summary>
    /// The app's unique ID. It can't be changed.
    /// See more: https://yandex.ru/dev/id/doc/en/oauth-cabinet
    /// </summary>
    public string ClientId { get; set; } = default!;
    
    /// <summary>
    /// The app's secret key used to sign a JWT token with user information.
    /// See more: https://yandex.ru/dev/id/doc/en/oauth-cabinet
    /// </summary>
    public string ClientSecret { get; set; } = default!;
    
    /// <summary>
    /// The address of the page that the user will be redirected to after authorization. This is the page that will receive the OAuth token.
    /// See more: https://yandex.ru/dev/id/doc/en/oauth-cabinet
    /// </summary>
    public string RedirectUri { get; set; } = default!;
}