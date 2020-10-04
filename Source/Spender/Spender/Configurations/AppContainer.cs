using DryIoc;

namespace Spender.Configurations
{
    public sealed class AppContainer
    {
        private readonly Container container = new Container();
        static AppContainer()
        {
        }

        private AppContainer()
        {
        }

        public static AppContainer Instance { get; } = new AppContainer();

        public void Register<TService, TImplementation>() where TImplementation : TService
            => container.Register<TService, TImplementation>();

        public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
            => container.Register<TService, TImplementation>(Reuse.Singleton);

        public void Register<T>() => container.Register<T>();

        public void RegisterSingletone<T>() => container.Register<T>(Reuse.Singleton);

        public T Resolve<T>() => container.Resolve<T>();

    }
}
