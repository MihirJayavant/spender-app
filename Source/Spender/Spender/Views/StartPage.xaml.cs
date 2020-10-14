
using Core.Services;
using Infrastructure.Database;
using Infrastructure.Essentials;
using Spender.Configurations;
using Xamarin.Forms;

namespace Spender.Views
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var user = AppContainer.Instance.Resolve<IUserService>();
            var option = AppContainer.Instance.Resolve<IDbOption>();

            using var db = new ApplicationContext(option);
            await db.EnsureDbAsync();

            if(user.IsUserCreated)
                await Shell.Current.GoToAsync("//dashboard");
            else
                await Shell.Current.GoToAsync("//login");
        }
    }
}