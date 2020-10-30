
using Core.Services;
using Core.Transactional;
using Prism.Mvvm;
using System;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Spender.ViewModels
{
    public class DashboardViewModel : BindableBase
    {
        readonly IUserService userService;
        readonly IDivisionService divisionService;

        private User user;
        public User User
        {
            get => user;
            set => SetProperty(ref user, value);
        }

        public DashboardViewModel(IUserService userService, IDivisionService divisionService)
        {
            this.userService = userService;
            this.divisionService = divisionService;
        }

        public ObservableCollection<Division> DivisionList { get; set; } = new ObservableCollection<Division>();

        public async Task SetUser(int? id = null)
        {
            var result = await userService.Get(id);
            if (result.IsLoaded)
            {
                User = result.Data;
                await LoadDivision(result.Data.Id);
            }
        }

        public async Task LoadDivision(int userId)
        {
            var result = await divisionService.Get(userId);
            if (result.IsLoaded)
            {
                foreach (var item in result.Data)
                {
                    DivisionList.Add(item);
                }
            }

        }
    }
}
