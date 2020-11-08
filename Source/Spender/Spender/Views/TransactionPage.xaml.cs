using Spender.Configurations;
using Spender.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Spender.Views
{
    [DesignTimeVisible(false)]
    [QueryProperty("DivisionId", "divisionId")]
    public partial class TransactionPage : ContentPage
    {
        readonly TransactionPageViewModel vm;

        public string DivisionId { get; set; }
        public TransactionPage()
        {
            InitializeComponent();
            BindingContext = vm = AppContainer.Instance.Resolve<TransactionPageViewModel>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            int.TryParse(DivisionId, out int id);
            await vm.SetId(id);
        }
    }
}