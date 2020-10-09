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

        private void DropDown_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            vm.OnDropDownChange();
        }
    }
}