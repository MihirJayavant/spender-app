using Core.Services;
using System.Globalization;
using Xamarin.CommunityToolkit.Helpers;

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
        public LocalizationService(ILocalStorage localStorage)
            => this.localStorage = localStorage;

        public void SetLanguage(string code)
        {
            localStorage.Set("language", code);
            var culture = new CultureInfo(code);
            LocalizationResourceManager.Current.CurrentCulture = culture;
        }

        public void SetCurrency(string cultureCode) => localStorage.Set("currency", cultureCode);

        public string GetLanguage() 
            => localStorage.Get("language", "en");

        public string GetCurrency() => localStorage.Get("currency", "en-US");

    }
}
