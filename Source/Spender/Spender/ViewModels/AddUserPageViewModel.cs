using Prism.Commands;
using Prism.Mvvm;

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

        public AddUserPageViewModel()
        {
            NextCommand = new DelegateCommand(GoToDashBoard).ObservesCanExecute(() => IsEnabled);
        }

        private void GoToDashBoard()
        {
            
        }
    }
}
