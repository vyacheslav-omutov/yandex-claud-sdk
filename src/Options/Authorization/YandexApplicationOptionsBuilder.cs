using Microsoft.Extensions.DependencyInjection;

namespace Yandex.ID.Options.Authorization;

public class YandexApplicationOptionsBuilder(IServiceCollection serviceCollection) : IYandexApplicationOptionsInfrastructure
{
    public void AddYandexApplication(Action<YandexApplicationOption> setupAction) =>
        serviceCollection.Configure(setupAction);
}