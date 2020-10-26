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
                string s => GetFirstLetter(s),
                _ => "A"
            };


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => value switch
            {
                null => string.Empty,
                string s => s,
                _ => string.Empty
            };

        public string GetFirstLetter(string s) => StringInfo.GetNextTextElement(s).ToUpperInvariant();

    }
}
