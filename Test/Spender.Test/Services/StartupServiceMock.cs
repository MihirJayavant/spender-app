using Moq;
using Core.Services;
using System.Threading.Tasks;

namespace Spender.Test.Services
{
    public static class StartupServiceMock
    {
        public static Mock<IStartupService> Get()
        {
            var mock = new Mock<IStartupService>();
            mock.Setup(u => u.EnsureCreation()).Returns(Task.CompletedTask);
            return mock;
        }
    }
}
