using Spender.Configurations;
using Spender.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Spender.Views
{
    [DesignTimeVisible(false)]
    public partial class TransactionPage : ContentPage
    {
        readonly TransactionPageViewModel vm;
        public TransactionPage()
        {
            InitializeComponent();
            BindingContext = vm = AppContainer.Instance.Resolve<TransactionPageViewModel>();
        }
    }
}