

namespace Core.Localization
{
    public static class Languages
    {
        public static ILanguage[] All
            => new ILanguage[]
            {
                new English(),
                new Hindi()
            };
    }
}
