

namespace Core.Services
{
    public interface ILocalStorage
    {
        bool Get(string key, bool defaultValue);
        string Get(string key, string defaultValue);
        void Set(string key, bool value);
        void Set(string key, string value);
        bool Has(string key);
    }
}
