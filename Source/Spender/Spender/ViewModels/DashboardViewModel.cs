using Core.Data;
using Core.Services;
using Core.Transactional;
using Prism.Mvvm;
using System.Threading.Tasks;

namespace Spender.ViewModels
{
    public class DashboardViewModel : BindableBase
    {
        readonly IUserService userService;

        private User user;
        public User User
        {
            get => user;
            set => SetProperty(ref user, value);
        }

        public DashboardViewModel(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task SetUser(int? id = null)
        {
            var result = await userService.Get(id);
            if (result.State == AsyncDataState.Loaded)
                User = result.Data;
        }
    }
}
