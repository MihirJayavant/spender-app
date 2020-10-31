using Spender.Configurations;
using Spender.ViewModels;
using System.ComponentModel;

using Xamarin.Forms;

namespace Spender.Views
{
    [DesignTimeVisible(false)]
    public partial class Dashboard : ContentPage
    {
        readonly DashboardViewModel vm;
        public Dashboard()
        {
            InitializeComponent();
            BindingContext = vm = AppContainer.Instance.Resolve<DashboardViewModel>();
        }

        protected override async void OnAppearing()
        {
            if(vm.User == null)
                await vm.SetUser();
        }

        private async void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync("transaction");
        }
    }
}