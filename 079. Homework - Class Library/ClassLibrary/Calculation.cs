using System.ComponentModel;
using System.Reflection.Emit;

namespace ClassLibrary
{
    public static class Calculation
    {
        public static T Add<T>(T firstNumber, T secondNumber)
        {
            return (dynamic)firstNumber + secondNumber;
        }

        public static T Multiply<T>(T firstNumber, T secondNumber)
        {
            return (dynamic)firstNumber * secondNumber;
        }

        public static T Difference<T>(T firstNumber, T secondNumber)
        {
            if ((dynamic)firstNumber > secondNumber)
            {
                return (dynamic)firstNumber - secondNumber;
            }
            return (dynamic)secondNumber- firstNumber;
        }

    }
}
