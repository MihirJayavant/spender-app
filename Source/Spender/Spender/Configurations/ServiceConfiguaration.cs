using Core.Services;
using Infrastructure.Essentials;
using Infrastructure.Services.Database;
using Prism.Events;
using Spender.Localization;
using Spender.Services;

using mem = Infrastructure.Services.InMemory;

namespace Spender.Configurations
{
    public static class ServiceConfiguration
    {
        public static void AddServices(this AppContainer container)
        {
#if DEBUG
            container.AddDevServices();
#else
            container.AddProdServices();
#endif
        }

        private static void AddDevServices(this AppContainer container)
        {
            var settings = new DevSettings();

            if (settings.UseEssentials)
                container.Register<ILocalStorage, LocalStorage>();
            else
                container.Register<ILocalStorage, InMemoryStorage>();

            if(settings.UseDatabase)
            {
                container.Register<IUserService, UserService>();
            }
            else
            {
                container.Register<IUserService, mem.UserService>();
            }

            container.RegisterSingleton<ISettings, DevSettings>();
            container.RegisterSingleton<IEventAggregator, EventAggregator>();
            container.Register<ILocalizationService, LocalizationService>();
            container.Register<INavigation, Navigation>();
            container.RegisterSingleton<IDbOption, DbOptions>();
            container.RegisterSingleton<LocalizationResourceManager>();
        }

        private static void AddProdServices(this AppContainer container)
        {
            container.Register<ILocalStorage, LocalStorage>();
            container.RegisterSingleton<ISettings, ProdSettings>();
            container.RegisterSingleton<IEventAggregator, EventAggregator>();
            container.Register<ILocalizationService, LocalizationService>();
            container.Register<IUserService, UserService>();
            container.RegisterSingleton<IDbOption, DbOptions>();
            container.Register<INavigation, Navigation>();
            container.RegisterSingleton<LocalizationResourceManager>();
        }

    }
}
