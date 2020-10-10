

using Core.Services;
using Spender.Localization;
using System.Globalization;

namespace Spender.Services
{

    public interface ILocalizationService
    {
        void SetLanguage(string code);
        void SetCurrency(string cultureCode);
        string GetLanguage();
        string GetCurrency();
    }

    public class LocalizationService : ILocalizationService
    {
        readonly ILocalStorage localStorage;
        readonly LocalizationResourceManager manager;
        public LocalizationService(ILocalStorage localStorage, LocalizationResourceManager manager)
            => (this.localStorage, this.manager) = (localStorage, manager);

        public void SetLanguage(string code)
        {
            localStorage.Set("language", code);
            var culture = new CultureInfo(code);
            manager.SetCulture(culture);
        }

        public void SetCurrency(string cultureCode) => localStorage.Set("currency", cultureCode);

        public string GetLanguage() 
            => localStorage.Get("language", "en");

        public string GetCurrency() => localStorage.Get("currency", "en-US");

    }
}
