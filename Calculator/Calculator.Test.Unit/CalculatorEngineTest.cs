using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculator.Test.Unit
{
    [TestClass]
    public class CalculatorEngineTest
    {
        private readonly CalculatorEngine _calculatorEngine =new CalculatorEngine();

        [TestMethod]
        public void AddsTwoNumbersAndReturnsValidResultForNonSumbolOperation()
        {
            int number1 = 1;
            int number2 = 2;

            double result = _calculatorEngine.Calculate("add",number1 ,number2);
            Assert.AreEqual(3, result);
        }
        [TestMethod]
        public void AddsTwoNumbersAndReturnsValidResultForSumbolOperation()
        {
            int number1 = 1;
            int number2 = 2;

            double result = _calculatorEngine.Calculate("+", number1, number2);
            Assert.AreEqual(3, result);
        }
    }
}
