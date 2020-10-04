using Spender.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Spender.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguagePage : ContentPage
    {
        public LanguagePage()
        {
            InitializeComponent();
            BindingContext = new LanguagePageViewModel();
        }
    }
}