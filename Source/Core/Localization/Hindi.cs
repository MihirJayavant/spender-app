using System.Globalization;
using System.Linq;

namespace Core.Localization
{
    public sealed class Hindi : ILanguage
    {
        public Country[] Countries
        {
            get
            {
                CultureInfo[] culture2 = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
                return culture2.Where(p => p.TwoLetterISOLanguageName == "hi")
                        .Select(p => new Country(p))
                        .ToArray();
            }
        }

        public string Name => "Hindi";

        public string ISOTwoLetterCode => "hi";

        public string DisplayName => "हिंदी";
    }
}
