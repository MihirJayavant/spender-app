using System.Globalization;
using System.Linq;

namespace Core.Localization
{
    public sealed class English : ILanguage
    {
        public Country[] Countries
        {
            get
            {
                CultureInfo[] culture2 = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
                return culture2.Where(p => p.TwoLetterISOLanguageName == "en")
                        .Select(p => new Country(p))
                        .ToArray();
            }
        }

        public string Name => "English";

        public string ISOTwoLetterCode => "en";

        public string DisplayName => "English";
    }
}
