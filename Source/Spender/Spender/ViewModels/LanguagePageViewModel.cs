using Core.Localization;
using Prism.Mvvm;

namespace Spender.ViewModels
{
    class LanguagePageViewModel : BindableBase
    {
        public ILanguage[] LanguageList { get; }
        public Country[] CountryList { get; }

        private int selectedLanguage;

        public int SelectedLanguage
        {
            get => selectedLanguage;
            set => SetProperty(ref selectedLanguage, value);
        }


        internal LanguagePageViewModel()
        {
            LanguageList = Languages.All;
            selectedLanguage = 0;
            CountryList = new English().Countries;
        }
    }
}
