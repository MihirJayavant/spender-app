using Core.Localization;
using Prism.Mvvm;

namespace Spender.ViewModels
{
    class LanguagePageViewModel : BindableBase
    {
        public ILanguage[] LanguageList { get; }

        private int selected;

        public int Selected
        {
            get => selected;
            set => SetProperty(ref selected, value);
        }


        internal LanguagePageViewModel()
        {
            LanguageList = Languages.All;
            selected = 0;
        }
    }
}
