using Core.Localization;
using Prism.Commands;
using Prism.Mvvm;
using Spender.Services;

namespace Spender.ViewModels
{
    public class LanguagePageViewModel : BindableBase
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

        readonly ILocalizationService localizationService;
        readonly INavigation navigation;


        public LanguagePageViewModel(ILocalizationService localizationService, INavigation navigation)
        {
            LanguageList = Languages.All;
            SelectedLanguageIndex = -1;
            SelectedCountryIndex = -1;
            CountryList = new English().Countries;

            NextCommand = new DelegateCommand(GoToUserPage).ObservesCanExecute(() => IsEnabled);
            this.localizationService = localizationService;
            this.navigation = navigation;
        }

        public void OnDropDownChange() => IsEnabled = selectedCountryIndex != -1 && selectedLanguageIndex != -1;

        public void OnLangChange()
        {
            var selectedLang = LanguageList[selectedLanguageIndex];
            localizationService.SetLanguage(selectedLang.Countries[0].ISOLanguageCode);
            OnDropDownChange();
        }

        async void GoToUserPage()
        {
            var selectedLang = LanguageList[selectedLanguageIndex];
            var selectedCountry = CountryList[SelectedCountryIndex];

            localizationService.SetLanguage(selectedLang.Countries[0].ISOLanguageCode);
            localizationService.SetCurrency( selectedCountry.CultureCode);

            await navigation.GotoAsync("addUser");
        }
    }
}
