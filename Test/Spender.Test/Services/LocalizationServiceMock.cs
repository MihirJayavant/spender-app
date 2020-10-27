

using Moq;
using Spender.Services;

namespace Spender.Test.Services
{
    public static class LocalizationServiceMock
    {
        public static Mock<ILocalizationService> Get()
        {
            var mock = new Mock<ILocalizationService>();
            mock.Setup(l => l.SetCurrency(It.IsAny<string>()));
            mock.Setup(l => l.SetLanguage(It.IsAny<string>()));
            mock.Setup(l => l.GetLanguage()).Returns("en-US");
            mock.Setup(l => l.GetCurrency()).Returns("en-US");
            return mock;
        }
    }
}
