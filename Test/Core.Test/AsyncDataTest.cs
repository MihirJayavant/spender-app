using Core.Data;
using FluentAssertions;
using Xunit;

namespace Core.Test
{
    public class AsyncDataTest
    {

        [Fact]
        public void Initial_ShouldHave_DataAsNull_And_StateAsInitial()
        {
            var result = AsyncData<string>.Initial();

            result.Data.Should().BeNull();
            result.State.Should().Be(AsyncDataState.Initial);
        }

        [Fact]
        public void Loading_ShouldHave_DataAsNull_And_StateAsLoading()
        {
            var result = AsyncData<string>.Loading();

            result.Data.Should().BeNull();
            result.State.Should().Be(AsyncDataState.Loading);
        }

        [Fact]
        public void Loaded_ShouldHave_DataAsDone_And_StateAsLoaded()
        {
            var result = AsyncData<string>.Loaded("done");

            result.Data.Should().Be("done");
            result.State.Should().Be(AsyncDataState.Loaded);
        }

        [Fact]
        public void ErrorMessage_ShouldHave_DataAsNull_And_StateAsError()
        {
            var result = AsyncData<string>.ErrorMessage("error");

            result.Data.Should().BeNull();
            result.Error.Should().Be("error");
            result.State.Should().Be(AsyncDataState.Error);
        }

        [Fact]
        public void IsLoading_ShouldBe_True_And_Data_Null ()
        {
            var result = AsyncData<string>.Loading();

            result.Data.Should().BeNull();
            result.IsLoading.Should().BeTrue();
        }

        [Fact]
        public void IsLoading_ShouldBe_True_And_Data_Should_NotBeNull()
        {
            var result = AsyncData<string>.Loading("loading data");

            result.Data.Should().NotBeNull();
            result.IsLoading.Should().BeTrue();
        }

        [Fact]
        public void IsLoading_ShouldBe_False_And_Data_Null()
        {
            var result = AsyncData<string>.Initial();

            result.Data.Should().BeNull();
            result.IsLoading.Should().BeFalse();
        }

        [Fact]
        public void IsLoaded_ShouldBe_True_And_Data_Not_Null()
        {
            var result = AsyncData<string>.Loaded("loaded");

            result.Data.Should().NotBeNull();
            result.IsLoaded.Should().BeTrue();
        }
        [Fact]
        public void IsLoaded_ShouldBe_False_And_Data_Null()
        {
            var result = AsyncData<string>.ErrorMessage("error");

            result.Data.Should().BeNull();
            result.IsLoaded.Should().BeFalse();
        }

        [Fact]
        public void HasError_ShouldBe_True_And_Data_Null()
        {
            var result = AsyncData<string>.ErrorMessage("error");

            result.Data.Should().BeNull();
            result.HasError.Should().BeTrue();
            result.Error.Should().Be("error");
        }

        [Fact]
        public void HasError_ShouldBe_True_And_Data_Not_Null()
        {
            var result = AsyncData<string>.ErrorMessage("error", "result");

            result.Data.Should().NotBeNull();
            result.HasError.Should().BeTrue();
            result.Error.Should().Be("error");
        }

        [Fact]
        public void HasError_ShouldBe_False_And_Data_Null()
        {
            var result = AsyncData<string>.Loaded("error");

            result.Data.Should().NotBeNull();
            result.HasError.Should().BeFalse();
        }
    }
}
