using Spender.Configurations;
using Spender.ViewModels;
using Xamarin.Forms;

namespace Spender.Views
{
    public partial class LanguagePage : ContentPage
    {
        LanguagePageViewModel vm;
        public LanguagePage()
        {
            InitializeComponent();
            BindingContext = vm = AppContainer.Instance.Resolve<LanguagePageViewModel>();
        }

        private void LangChanged(object sender, System.EventArgs e) => vm.OnLangChange();

        private void CountryChanged(object sender, System.EventArgs e) => vm.OnDropDownChange();
    }
}