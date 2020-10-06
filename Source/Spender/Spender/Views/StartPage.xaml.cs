
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
            await Shell.Current.GoToAsync("//login");
        }
    }
}