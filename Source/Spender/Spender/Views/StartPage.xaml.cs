

using Spender.Configurations;
using Spender.ViewModels;
using Xamarin.Forms;

namespace Spender.Views
{
    public partial class StartPage : ContentPage
    {
        readonly StartPageViewModel vm;
        public StartPage()
        {
            InitializeComponent();
            BindingContext = vm = AppContainer.Instance.Resolve<StartPageViewModel>();
        }

        protected override async void OnAppearing()
        {
            await vm.OnStart();
        }
    }
}