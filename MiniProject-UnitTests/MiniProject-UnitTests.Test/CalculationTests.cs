namespace MiniProject_UnitTests.Test
{
    public class CalculationTests
    {
        [Theory]
        [InlineData(4,2,6)]
        [InlineData(14, 12, 26)]
        [InlineData(0, 0, 0)]
        [InlineData(10, 12, 22)]
        [InlineData(1231234, -1231234, 0)]
        [InlineData(-4, 2, -2)]
        [InlineData(-4, -2, -6)]

        public void AddShouldReturnExpectedValue(double first, double second,double expected)
        {
            //Arrange
            Calculations calc = new Calculations();

            //Act
            double actual = calc.Add(first, second);

            //Assert
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(230, 10, 220)]
        [InlineData(0, 0, 0)]
        [InlineData(20, 10, 10)]
        [InlineData(-230, 1210, -1440)]
        public void SubstractShouldReturnExpectedValue(double first, double second, double expected)
        {
            //Arrange
            Calculations calc = new Calculations();

            //Act
            double actual = calc.Substract(first, second);

            //Assert
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(4, 5, 20)]
        [InlineData(10, 20, 200)]
        [InlineData(140, 2, 280)]
        [InlineData(123, 12, 1476)]
        public void MultiplyShouldReturnExpectedValue(double first, double second, double expected)
        {
            //Arrange
            Calculations calc = new Calculations();

            //Act
            double actual = calc.Multiply(first, second);

            //Assert
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(0, 0,0)]
        [InlineData(20, 5, 4)]
        [InlineData(10, 20, 0.5)]
        [InlineData(140, 2, 70)]
        [InlineData(-12, 12, -1)]
        public void DivideShouldReturnExpectedValue(double first, double second, double expected)
        {
            //Arrange
            Calculations calc = new Calculations();

            //Act
            double actual = calc.Divide(first, second);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}