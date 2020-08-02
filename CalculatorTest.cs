using System;
using Xunit;

namespace XUnitTestProject
{
    public class CalculatorTest
    {
        [Fact]
        public void MyAdd_Fact()
        {
            var expected = 3;
            //Act
            var result = AvidTest.Calculator.MyAdd(1, 2);
            //Assert 
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2.2, 2, 4.2)]
        [InlineData(double.MaxValue, 5, double.MaxValue)]
        public void MyAdd_Theory(double a, double b, double z)
        {
            //Act
            var result = AvidTest.Calculator.MyAdd(a, b);
            //Assert 
            Assert.Equal(z, result);
        }

    }
}
