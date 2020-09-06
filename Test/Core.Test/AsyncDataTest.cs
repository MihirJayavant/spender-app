using Core.AsyncData;
using FluentAssertions;
using Xunit;

namespace Core.Test
{
    public class AsyncDataTest
    {

        [Fact]
        public void Initial_ShouldHave_DataAsNull_And_StateAsInitial()
        {
            var data = AsyncData<string>.Initial();

            data.Data.Should().BeNull();
            data.State.Should().Be(AsyncDataState.Initial);
        }

        [Fact]
        public void Loading_ShouldHave_DataAsNull_And_StateAsLoading()
        {
            var data = AsyncData<string>.Loading();

            data.Data.Should().BeNull();
            data.State.Should().Be(AsyncDataState.Loading);
        }

        [Fact]
        public void Loaded_ShouldHave_DataAsDone_And_StateAsLoaded()
        {
            var data = AsyncData<string>.Loaded("done");

            data.Data.Should().Be("done");
            data.State.Should().Be(AsyncDataState.Loaded);
        }

        [Fact]
        public void ErrorMessage_ShouldHave_DataAsNull_And_StateAsError()
        {
            var data = AsyncData<string>.ErrorMessage("error");

            data.Data.Should().BeNull();
            data.Error.Should().Be("error");
            data.State.Should().Be(AsyncDataState.Error);
        }
    }
}
