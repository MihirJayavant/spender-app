using Core.Services;
using Infrastructure.Essentials;
using Infrastructure.Services.Database;
using Prism.Events;
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
                container.RegisterSingleton<IUserService, UserService>();
                container.Register<IStartupService, StartupService>();
                container.Register<IDivisionService, DivisionService>();
                container.Register<ITransactionService, TransactionService>();
            }
            else
            {
                container.RegisterSingleton<IUserService, mem.UserService>();
                container.Register<IStartupService, mem.StartupService>();
                container.Register<IDivisionService, mem.DivisionService>();
                container.Register<ITransactionService, mem.TransactionService>();
            }

            container.RegisterSingleton<ISettings, DevSettings>();
            container.RegisterSingleton<IEventAggregator, EventAggregator>();
            container.RegisterSingleton<IDbOption, DbOptions>();

            container.Register<ILocalizationService, LocalizationService>();
            container.Register<INavigation, Navigation>();
        }

        private static void AddProdServices(this AppContainer container)
        {
            container.RegisterSingleton<ISettings, ProdSettings>();
            container.RegisterSingleton<IEventAggregator, EventAggregator>();
            container.RegisterSingleton<IUserService, UserService>();

            container.Register<ILocalStorage, LocalStorage>();
            container.Register<ILocalizationService, LocalizationService>();
            container.RegisterSingleton<IDbOption, DbOptions>();
            container.Register<INavigation, Navigation>();
        }

    }
}
