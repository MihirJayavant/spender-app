using Core.Services;
using Xamarin.Essentials;

namespace Spender.Services
{
    class LocalStorage : ILocalStorage
    {
        public bool Get(string key, bool defaultValue)
            => Preferences.Get(key, defaultValue);

        public string Get(string key, string defaultValue)
            => Preferences.Get(key, defaultValue);

        public bool Has(string key)
            => Preferences.ContainsKey(key);

        public bool IsUserCreated()
            => Preferences.Get("HasUser", false);

        public void Set(string key, bool value)
            => Preferences.Set(key, value);

        public void Set(string key, string value)
            => Preferences.Set(key, value);
    }
}
