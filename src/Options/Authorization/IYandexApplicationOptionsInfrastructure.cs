namespace Yandex.ID.Options.Authorization;

public interface IYandexApplicationOptionsInfrastructure
{
    void AddYandexApplication(Action<YandexApplicationOption> setupAction);
}