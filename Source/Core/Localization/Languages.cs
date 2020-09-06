

namespace Core.Localization
{
    public static class Languages
    {
        public static ILanguage[] GetLanguages() 
            => new ILanguage[]
            {
                new English(),
                new Hindi()
            };
    }
}
