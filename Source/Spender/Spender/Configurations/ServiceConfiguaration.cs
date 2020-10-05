

using Prism.Events;

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

            if (settings.IsLocalDev)
            {
                
            }
            else
            {
                
            }

            container.RegisterSingleton<ISettings, DevSettings>();
            container.RegisterSingleton<IEventAggregator, EventAggregator>();
        }

        private static void AddProdServices(this AppContainer container)
        {
            container.RegisterSingleton<ISettings, ProdSettings>();
            container.RegisterSingleton<IEventAggregator, EventAggregator>();
        }

    }
}
