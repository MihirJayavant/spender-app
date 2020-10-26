using Moq;
using Core.Services;

namespace Spender.Test.Services
{
    public static class UserServiceMock
    {
        public static Mock<IUserService> WithFalseUserCreated()
        {
            var mock = new Mock<IUserService>();
            mock.Setup(u => u.IsUserCreated).Returns(false);
            return mock;
        }

        public static Mock<IUserService> WithTrueUserCreated()
        {
            var mock = new Mock<IUserService>();
            mock.Setup(u => u.IsUserCreated).Returns(true);
            return mock;
        }
    }
}
