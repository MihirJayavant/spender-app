
using Spender.Resx;
using System.ComponentModel;
using System.Globalization;
using System.Threading;

namespace Spender.Localization
{

    public class LocalizationResourceManager : INotifyPropertyChanged
    {

        public string this[string text] => AppResources.ResourceManager.GetString(text, AppResources.Culture);

        public void SetCulture(CultureInfo language)
        {
            Thread.CurrentThread.CurrentUICulture = language;
            AppResources.Culture = language;

            Invalidate();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Invalidate() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
    }
}
