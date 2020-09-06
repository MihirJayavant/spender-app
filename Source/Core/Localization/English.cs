

using System.Globalization;
using System.Linq;

namespace Core.Localization
{
    public class English
    {
        public string[] Countries
        {
            get
            {
                CultureInfo[] culture2 = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
                return culture2.Where(p => p.TwoLetterISOLanguageName == "en")
                        .Select(p => new RegionInfo(p.LCID).DisplayName.ToString())
                        .ToArray();
            }
        }
    }
}
