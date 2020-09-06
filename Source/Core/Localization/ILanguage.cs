
namespace Core.Localization
{
    public interface ILanguage
    {
        public string Name { get; }
        public string ISOTwoLetterCode { get; }
        public Country[] Countries { get; }
    }
}
