using Core.Data;
using Core.Services;
using Core.Transactional;
using Prism.Commands;
using Prism.Mvvm;
using Spender.Services;
using System;

namespace Spender.ViewModels
{
    public class AddUserPageViewModel : BindableBase
    {
        private string name;

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private bool isEnabled;
        public bool IsEnabled
        {
            get => isEnabled;
            set => SetProperty(ref isEnabled, value);
        }


        public DelegateCommand NextCommand { get; set; }

        readonly IUserService userService;
        readonly INavigation navigation;
        readonly IDivisionService divisionService;

        public AddUserPageViewModel(IUserService userService, IDivisionService divisionService, INavigation navigation)
        {
            NextCommand = new DelegateCommand(GoToDashboard).ObservesCanExecute(() => IsEnabled);
            this.userService = userService;
            this.navigation = navigation;
            this.divisionService = divisionService;
        }

        private async void GoToDashboard()
        {
            var result = await userService.Add(name);
            if(result.State == AsyncDataState.Loaded)
            {
                var div1 = new Division(0, "Salary", "", Categories.Parse(CategoryType.Salary), DateTime.Now, DateTime.Now);
                var div2 = new Division(0, "Others", "", Categories.Parse(CategoryType.Other), DateTime.Now, DateTime.Now);
                await divisionService.Add(div1, result.Data.Id);
                await divisionService.Add(div2, result.Data.Id);
                await navigation.GotoAsync("//dashboard");
            }
            else
                System.Console.WriteLine(result.Error);
        }
    }
}
