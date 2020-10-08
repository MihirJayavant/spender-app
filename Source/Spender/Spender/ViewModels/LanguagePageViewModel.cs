using Core.Localization;
using Prism.Commands;
using Prism.Mvvm;

namespace Spender.ViewModels
{
    class LanguagePageViewModel : BindableBase
    {
        public ILanguage[] LanguageList { get; }
        public Country[] CountryList { get; }

        private int selectedLanguageIndex;

        public int SelectedLanguageIndex
        {
            get => selectedLanguageIndex;
            set => SetProperty(ref selectedLanguageIndex, value);
        }

        private int selectedCountryIndex;

        public int SelectedCountryIndex
        {
            get => selectedCountryIndex;
            set => SetProperty(ref selectedCountryIndex, value);
        }

        private bool isEnabled = false;
        public bool IsEnabled
        {
            get => isEnabled; 
            set => SetProperty(ref isEnabled, value);
        }

        public DelegateCommand NextCommand { get; }


        internal LanguagePageViewModel()
        {
            LanguageList = Languages.All;
            selectedLanguageIndex = -1;
            SelectedCountryIndex = -1;
            CountryList = new English().Countries;

            NextCommand = new DelegateCommand(GoToUserPage).ObservesCanExecute(() => IsEnabled);
        }

        public void OnDropDownChange()
        {
            if (selectedCountryIndex != -1 && selectedLanguageIndex != -1)
                IsEnabled = true;
            else
                IsEnabled = false;

        }

        void GoToUserPage()
        {
            System.Console.WriteLine("Goto User Page");
        }
    }
}
