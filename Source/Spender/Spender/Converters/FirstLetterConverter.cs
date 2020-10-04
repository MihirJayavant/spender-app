using System;
using System.Globalization;
using Xamarin.Forms;

namespace Spender.Converters
{
    public class FirstLetterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value switch
            {
                null => "A",
                string s when s.Length == 0 => "A",
                string s => char.ToUpper(s[0]),
                _ => "A"
            };


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => value switch
            {
                null => string.Empty,
                string s => s,
                _ => string.Empty
            };

    }
}
