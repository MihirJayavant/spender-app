using Spender.Resx;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;

namespace Spender
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            LocalizationResourceManager.Current.PropertyChanged += 
                (_, __) => AppResources.Culture = LocalizationResourceManager.Current.CurrentCulture;
            LocalizationResourceManager.Current.Init(AppResources.ResourceManager);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
