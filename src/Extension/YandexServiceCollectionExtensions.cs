using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Yandex.ID.Options.Authorization;
using Yandex.ID.Services.Authorization;

namespace Yandex.ID.Extension;

public static class YandexServiceCollectionExtensions
{
    public static IServiceCollection AddYandexId(this IServiceCollection serviceCollection,
        Action<YandexApplicationOptionsBuilder> optionBuilder)
    {
        AddYandexApplicationOptions(serviceCollection, optionBuilder);
        
        serviceCollection.AddYandexClients();
        serviceCollection.TryAddTransient<IYandexAuthorizationService, YandexAuthorizationService>();
        
        return serviceCollection;
    }

    private static void AddYandexApplicationOptions(IServiceCollection serviceCollection,
        Action<YandexApplicationOptionsBuilder> optionBuilder)
    {
        ArgumentNullException.ThrowIfNull(serviceCollection);
        ArgumentNullException.ThrowIfNull(optionBuilder);
        
        optionBuilder.Invoke(new YandexApplicationOptionsBuilder(serviceCollection));
    }
}