using Spender.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spender.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguagePage : ContentPage
    {
        LanguagePageViewModel vm;
        public LanguagePage()
        {
            InitializeComponent();
            BindingContext = vm = new LanguagePageViewModel();
        }

        private void DropDown_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            vm.OnDropDownChange();
        }
    }
}