using Xamarin.Forms;
using Spender.Views;

namespace Spender
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("language", typeof(LanguagePage));
        }

        protected override async void OnAppearing()
        {
            //await Current.GoToAsync("//language", true);
        }

    }
}
