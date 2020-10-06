using System.Globalization;

namespace Core.Localization
{
    public sealed class Country
    {
        public string Name { get; }
        public string CurrencySymbol { get; }
        public string CultureCode { get; }
        public string Display => $"{Name} ({CurrencySymbol})";

        public Country(CultureInfo culture)
        {
            var region = new RegionInfo(culture.LCID);
            Name = region.DisplayName;
            CurrencySymbol = region.CurrencySymbol;
            CultureCode = culture.Name;
        }
    }
}
