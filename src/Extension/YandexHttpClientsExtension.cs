using Microsoft.Extensions.DependencyInjection;

namespace Yandex.ID.Extension;

public static class YandexHttpClientsExtension
{
    public static IServiceCollection AddYandexClients(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHttpClient("YandexAuthorization", client =>
        {
            client.BaseAddress = new Uri("https://oauth.yandex.com");
        });
        
        return serviceCollection;
    }
}