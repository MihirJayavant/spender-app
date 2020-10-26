using Xunit;
using Spender.ViewModels;
using Spender.Test.Services;
using System.Threading.Tasks;
using Moq;

namespace Spender.Test
{
    public class StartPageViewModelTest
    {
        [Fact]
        public async Task VM_AlwaysCalls_EnsureCreated_Even_When_UserCreated()
        {
            var user = UserServiceMock.WithTrueUserCreated();
            var nav = NavigationMock.Get();
            var startup = StartupServiceMock.Get();
            var vm = new StartPageViewModel(user.Object, startup.Object, nav.Object);

            await vm.OnStart();

            startup.Verify(s => s.EnsureCreation(), Times.Once);
        }

        [Fact]
        public async Task VM_AlwaysCalls_EnsureCreated_Even_When_UserNotCreated()
        {
            var user = UserServiceMock.WithFalseUserCreated();
            var nav = NavigationMock.Get();
            var startup = StartupServiceMock.Get();
            var vm = new StartPageViewModel(user.Object, startup.Object, nav.Object);

            await vm.OnStart();

            startup.Verify(s => s.EnsureCreation(), Times.Once);
        }
    }
}
