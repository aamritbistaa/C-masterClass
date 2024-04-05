using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InputConverterTest
{
    [TestClass]
    public class InputConverterTest
    {

        private readonly InputConverter _inputConverter = new InputConverter();
        [TestMethod]
        public void ConvertsValidStringInputIntoDouble()
        {
            string inputNumber = "5";
            double convertedNumber = _inputConverter.ConvertInputToNumber(inputNumber);
            Assert.AreEqual(5, convertedNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FailsToConvertInvalidStringInputIntoDouble()
        {
            string inputNumber = "s";
            double convertedNumber = _inputConverter.ConvertInputToNumber(inputNumber);
            
            Assert.AreEqual(5, convertedNumber);
        }
    }
}
