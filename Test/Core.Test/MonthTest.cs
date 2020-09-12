using Core.Transaction;
using FluentAssertions;
using System;
using Xunit;

namespace Core.Test
{
    public class MonthTest
    {
        [Fact]
        public void GetLast12Month_Test_Should_Return_12_to_1_Months()
        {
            var data = Month.GetLastt12Months(new DateTime(2019, 12, 12));

            data.Length.Should().Be(12);

            data[0].MonthNumber.Should().Be(12);
            data[1].MonthNumber.Should().Be(11);
            data[6].MonthNumber.Should().Be(6);
            data[11].MonthNumber.Should().Be(1);
        }

        [Fact]
        public void GetLast12Month_Test_Should_Return_6_to_7_Months()
        {
            var data = Month.GetLastt12Months(new DateTime(2019, 6, 20));

            data.Length.Should().Be(12);

            data[0].MonthNumber.Should().Be(6);
            data[1].MonthNumber.Should().Be(5);
            data[6].MonthNumber.Should().Be(12);
            data[11].MonthNumber.Should().Be(7);
        }
    }
}
