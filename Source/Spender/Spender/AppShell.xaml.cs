using Xamarin.Forms;
using Spender.Configurations;

namespace Spender
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            AppContainer.Instance.AddServices();
            AppContainer.Instance.AddViewModels();
        }

    }
}
