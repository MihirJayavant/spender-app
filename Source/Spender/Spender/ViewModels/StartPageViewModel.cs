using Core.Services;
using Prism.Mvvm;
using Spender.Services;
using System.Threading.Tasks;

namespace Spender.ViewModels
{
    public class StartPageViewModel : BindableBase
    {
        readonly IUserService user;
        readonly INavigation navigation;
        readonly IStartupService startup;

        public StartPageViewModel(IUserService userService, IStartupService startup, INavigation navigation)
            => (user, this.startup, this.navigation) = (userService, startup, navigation);

        public async Task OnStart()
        {
            await startup.EnsureCreation();

            if (user.IsUserCreated)
                await navigation.GotoAsync("//dashboard");
            else
                await navigation.GotoAsync("//login");
        }
    }
}
