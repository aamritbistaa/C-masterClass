using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {


                InputConverter inputConverter = new InputConverter();

                CalculatorEngine calculatorEngine = new CalculatorEngine();

                Console.WriteLine("Enter First number: ");
                double firstNumber = inputConverter.ConvertInputToNumber(Console.ReadLine());

                Console.WriteLine("Enter Second number: ");

                double secondNumber = inputConverter.ConvertInputToNumber(Console.ReadLine());

                Console.WriteLine("Enter Operation\nADD +\nSUBTRACT -\nDIVIDE /\nMULTIPLY *: ");

                string operation = Console.ReadLine();

                double result = calculatorEngine.Calculate(operation, firstNumber, secondNumber);
                Console.WriteLine(result);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
