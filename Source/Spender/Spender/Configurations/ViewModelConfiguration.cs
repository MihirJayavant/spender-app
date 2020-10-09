using Spender.ViewModels;

namespace Spender.Configurations
{
    static class ViewModelConfiguration
    {
        public static void AddViewModels(this AppContainer container)
        {
            container.Register<LanguagePageViewModel>();
        }

    }
}
