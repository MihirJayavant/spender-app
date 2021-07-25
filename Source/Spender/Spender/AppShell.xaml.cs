using Xamarin.Forms;
using Spender.Configurations;
using Spender.Services;
using System.Globalization;
using Spender.Views;
using Xamarin.CommunityToolkit.Helpers;

namespace Spender
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            AppContainer.Instance.AddServices();
            AppContainer.Instance.AddViewModels();

            Routing.RegisterRoute("addUser", typeof(AddUserPage));
            Routing.RegisterRoute("transaction", typeof(TransactionPage));

            var currentLang = AppContainer.Instance.Resolve<ILocalizationService>();
            var culture = new CultureInfo(currentLang.GetLanguage());
            LocalizationResourceManager.Current.CurrentCulture = culture;
        }

    }
}
