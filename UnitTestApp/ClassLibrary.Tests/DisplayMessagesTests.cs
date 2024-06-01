using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Arrange, Act,Assert
namespace ClassLibrary.Tests
{
    public class DisplayMessagesTests
    {
        [Fact]
        public void GreetingShouldReturnGoodMorningMessage()
        {
            //Arrange
            DisplayMessage message = new DisplayMessage();
            string expected = "Good morning Amrit";
            
            //Act
            string actual = message.Greeting("Amrit", 6);
            
            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GreetingShouldReturnGoodAfternoonMessage()
        {
            //Arrange
            DisplayMessage message = new DisplayMessage();
            string expected = "Good afternoon Amrit";

            //Act
            string actual = message.Greeting("Amrit", 15);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GreetingShouldReturnGoodEveningMessage()
        {
            //Arrange
            DisplayMessage message = new DisplayMessage();
            string expected = "Good evening Amrit";

            //Act
            string actual = message.Greeting("Amrit", 19);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Amrit",0,"Go to bed Amrit")]
        [InlineData("Amrit", 1, "Go to bed Amrit")]
        [InlineData("Amrit", 2, "Go to bed Amrit")]
        [InlineData("Amrit", 3, "Go to bed Amrit")]
        [InlineData("Amrit", 4, "Go to bed Amrit")]
        [InlineData("Amrit", 5, "Good morning Amrit")]
        [InlineData("Amrit", 6, "Good morning Amrit")]
        [InlineData("Amrit", 7, "Good morning Amrit")]
        [InlineData("Amrit", 8, "Good morning Amrit")]
        [InlineData("Amrit", 9, "Good morning Amrit")]
        [InlineData("Amrit", 10, "Good morning Amrit")]
        [InlineData("Amrit", 11, "Good morning Amrit")]
        [InlineData("Amrit", 12, "Good afternoon Amrit")]
        [InlineData("Amrit", 13, "Good afternoon Amrit")]
        [InlineData("Amrit", 14, "Good afternoon Amrit")]
        [InlineData("Amrit", 15, "Good afternoon Amrit")]
        [InlineData("Amrit", 16, "Good afternoon Amrit")]
        [InlineData("Amrit", 17, "Good afternoon Amrit")]
        [InlineData("Amrit", 18, "Good evening Amrit")]
        [InlineData("Amrit", 19, "Good evening Amrit")]
        [InlineData("Amrit", 20, "Good evening Amrit")]
        [InlineData("Amrit", 21, "Good evening Amrit")]
        [InlineData("Amrit", 22, "Good evening Amrit")]
        [InlineData("Amrit", 23, "Good evening Amrit")]
        public void GreetingsShouldReturnExpectedValue(
            string firstName,
            int hourOfTheDay,
            string expected
            )
        {
            //Arrange
            DisplayMessage message = new DisplayMessage();
            //Actual
            string actual = message.Greeting(firstName, hourOfTheDay);
            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
