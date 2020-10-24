using Core.Data;
using Core.Services;
using Prism.Commands;
using Prism.Mvvm;
using Spender.Services;

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

        public AddUserPageViewModel(IUserService userService, INavigation navigation)
        {
            NextCommand = new DelegateCommand(GoToDashboard).ObservesCanExecute(() => IsEnabled);
            this.userService = userService;
            this.navigation = navigation;
        }

        private async void GoToDashboard()
        {
            var result = await userService.Add(name);
            if(result.State == AsyncDataState.Loaded)
                await navigation.GotoAsync("//dashboard");
            else
                System.Console.WriteLine(result.Error);
        }
    }
}
