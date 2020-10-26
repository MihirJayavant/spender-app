using Moq;
using Spender.Services;
using System.Threading.Tasks;

namespace Spender.Test.Services
{
    public static class NavigationMock
    {
        public static Mock<INavigation> Get()
        {
            var mock = new Mock<INavigation>();
            mock.Setup(u => u.GotoAsync(It.IsAny<string>())).Returns(Task.CompletedTask);
            return mock;
        }

    }
}
