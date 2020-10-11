
using Spender.Configurations;
using Spender.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Spender.Views
{
    [DesignTimeVisible(false)]
    public partial class AddUserPage : ContentPage
    {
        readonly AddUserPageViewModel vm;
        public AddUserPage()
        {
            InitializeComponent();
            BindingContext = vm = AppContainer.Instance.Resolve<AddUserPageViewModel>();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(vm.Name != null)
            {
                vm.IsEnabled = vm.Name.Length > 2;
            }
        }
    }
}