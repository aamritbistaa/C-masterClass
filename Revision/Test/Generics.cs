using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public interface IImplementation
    {
    }
    public class Implementation<T>:IImplementation 
    {
        private T firstNumber { get; set; }
        private T secondNumber { get; set; }
        public Implementation(T firstNumber, T secondNumber)
        {
            this.firstNumber = firstNumber;
            this.secondNumber = secondNumber;
        }
        public void Output()
        {
            Console.WriteLine($"The first number is {firstNumber}");
            Console.WriteLine($"The second number is {secondNumber}");
        }
        public T ReturnFirstNumber()
        {
            return firstNumber;
        }
    }
    internal class Generics
    {
        public int GetInputNumber(string message)
        {
            bool choice = true;
            int output = 0;
            Console.WriteLine(message);
            do
            {
                choice = int.TryParse(Console.ReadLine(), out output);
            } while (!choice);
            return output;
        }

        public void Display<T>(T[] items)
        {
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
        }
        public void MainFunction()
        {
            //Implementation<int> obj = new Implementation<int>();
            //obj.Input(10, 20);

            List<IImplementation> list = new List<IImplementation>();

            string choice="y";
            do
            {
                int firstNumber = GetInputNumber("First Number");
                int secondNumber = GetInputNumber("SecondNumber");
                list.Add(new Implementation<int>(firstNumber,secondNumber));
                Console.WriteLine("Press n to halt");
                
                choice = Console.ReadLine();

            } while (choice.ToLower() != "n");
            int[] integerArray = { 1, 2, 3 };
            double[] doubleArray = { 1.0, 2.0, 3.0 };
            string[] stringArray = { "Ram", "Shyam", "Hari" };

            Display(integerArray);
            Display(doubleArray);
            Display(stringArray);
            int count = 0;
            foreach (var item in list)
            {
                Console.WriteLine($"Printing {count}th terms");
                Implementation<int> ob = (Implementation<int>)item;
                ob.Output();
                Console.WriteLine("first number: "+ ob.ReturnFirstNumber());
                count++;
            }

        }
    }
}
