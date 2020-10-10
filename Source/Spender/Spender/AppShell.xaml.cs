using Xamarin.Forms;
using Spender.Configurations;
using Spender.Services;
using System.Globalization;
using Spender.Localization;

namespace Spender
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            AppContainer.Instance.AddServices();
            AppContainer.Instance.AddViewModels();

            var currentLang = AppContainer.Instance.Resolve<ILocalizationService>();
            var culture = new CultureInfo(currentLang.GetLanguage());
            var manager = AppContainer.Instance.Resolve<LocalizationResourceManager>();
            manager.SetCulture(culture);
        }

    }
}
