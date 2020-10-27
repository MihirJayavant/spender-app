using Xunit;
using Spender.ViewModels;
using Spender.Test.Services;
using System.Threading.Tasks;
using Moq;
using FluentAssertions;

namespace Spender.Test.ViewModels
{
    public class LanguagePageViewModelTest
    {
        [Fact]
        public void IsEnable_ShouldBe_False_OnBothIndex_NotSelected()
        {
            var nav = NavigationMock.Get();
            var local = LocalizationServiceMock.Get();
            var vm = new LanguagePageViewModel(local.Object, nav.Object);

            vm.OnDropDownChange();

            vm.IsEnabled.Should().BeFalse();
            vm.NextCommand.CanExecute().Should().BeFalse();
        }

        [Fact]
        public void IsEnable_ShouldBe_False_OnOnlyLanguage_Selected()
        {
            var nav = NavigationMock.Get();
            var local = LocalizationServiceMock.Get();
            var vm = new LanguagePageViewModel(local.Object, nav.Object);

            vm.SelectedLanguageIndex = 0;
            vm.OnDropDownChange();

            vm.IsEnabled.Should().BeFalse();
            vm.NextCommand.CanExecute().Should().BeFalse();
        }

        [Fact]
        public void IsEnable_ShouldBe_False_OnOnlyCountry_Selected()
        {
            var nav = NavigationMock.Get();
            var local = LocalizationServiceMock.Get();
            var vm = new LanguagePageViewModel(local.Object, nav.Object);

            vm.SelectedCountryIndex = 0;
            vm.OnDropDownChange();

            vm.IsEnabled.Should().BeFalse();
            vm.NextCommand.CanExecute().Should().BeFalse();
        }

        [Fact]
        public void IsEnable_ShouldBe_True_OnBoth_Selected()
        {
            var nav = NavigationMock.Get();
            var local = LocalizationServiceMock.Get();
            var vm = new LanguagePageViewModel(local.Object, nav.Object);

            vm.SelectedCountryIndex = 0;
            vm.SelectedLanguageIndex = 0;
            vm.OnDropDownChange();

            vm.IsEnabled.Should().BeTrue();
            vm.NextCommand.CanExecute().Should().BeTrue();
        }
    }
}
