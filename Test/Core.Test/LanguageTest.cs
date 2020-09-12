using Core.Localization;
using FluentAssertions;
using Xunit;

namespace Core.Test
{
    public class LanguageTest
    {
        [Fact]
        public void GetOnlyTwoLanguages()
        {
            var data = Languages.All;

            data.Length.Should().Be(2);
        }

        [Fact]
        public void GetOnlyOneCountryForHindiLanguage()
        {
            var data = new Hindi().Countries;

            data.Length.Should().Be(1);
        }
    }
}
