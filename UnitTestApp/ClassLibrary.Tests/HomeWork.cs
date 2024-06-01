using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Tests
{
    //Arrange , Act, Assert
    public class HomeWork
    {
        [Fact]
        public void MethodShouldDoThis()
        {
            //Arrange
            //Create Object of the class
            DisplayMessage dis = new DisplayMessage();

            //Act
            //Call the object
            string actual = dis.Greeting("Amrit", 10);
            //Assert 
            //check if both are same or not
            Assert.Equal("Good morning Amrit", actual);
        }
        [Theory]
        [InlineData("Amrit", 2,"Go to bed Amrit")]
        [InlineData("Amrit", 6, "Good morning Amrit")]

        [InlineData("Amrit", 12, "Good afternoon Amrit")]

        [InlineData("Amrit", 17, "Good afternoon Amrit")]
        [InlineData("Amrit", 18, "Good evening Amrit")]
        [InlineData("Amrit", 20, "Good evening Amrit")]
        [InlineData("Amrit", 23, "Good evening Amrit")]




        public void MethodShouldReturnTrue(string name, int hourOfDay,string Expected)
        {
            //Arrange
            //Create Object of the class
            DisplayMessage dis = new DisplayMessage();

            //Act
            //Call the object
            string actual = dis.Greeting(name, hourOfDay);
            //Assert 
            //check if both are same or not
            Assert.Equal(Expected, actual);
        }
    }
}
