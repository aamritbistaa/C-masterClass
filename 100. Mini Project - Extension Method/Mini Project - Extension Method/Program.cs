using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project___Extension_Method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person per=new Person();
            //Console.WriteLine("Enter your first name");
            //per.FirstName = Console.ReadLine();
            //Console.WriteLine("Enter your Last name");
            //per.LastName = Console.ReadLine();
            //Console.WriteLine("Enter your Age");

            per.FirstName = "Enter your first name".RequestString();
            per.LastName = "Enter your last name".RequestString();
            //--------THis two tare same thing-----------
            //per.Age="Enter your age".RequestInteger();
            //per.Age=Helpers.RequestInteger("Enter your age");

            per.Age = "Enter your age".RequestInteger(12,30);

            per.LastPurchased = "Enter your last purchased item".RequestString();

            Console.WriteLine(per.Age);
            //bool isValidAge = false;
            //int result;
            //if(!isValidAge) 
            //{
            //isValidAge=int.TryParse(Console.ReadLine(),out result);
            //    if (isValidAge)
            //    {
            //        per.Age = result;
            //    }
            //}
            Console.ReadLine();
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string LastPurchased { get; set; }
        public decimal CostOfLastPurchased { get; set; }
    }

    public static class Helpers
    {
        public static decimal CostOfItem(this string message)
        {
            return message.CostOfItem(false);
        }
        public static decimal CostOfItem(this string message,bool hasRange)
        {
            if (hasRange)
            {
                return message.CostOfItem(true, 100, 11000);
            }
            else
            {
               
                    return message.CostOfItem(false);
                
            }
        }

        private static decimal CostOfItem(this string message, bool hasRange, decimal minValue=0M, decimal maxValue = 0M)
        {
            decimal output = 0M;
            bool isInRange = !hasRange;  ///hasRange sets to true if hasRange is set to false
            bool isValidDecimal = false;
            while (isValidDecimal == false || isInRange==false)
            {
                Console.WriteLine(message);
                isValidDecimal = decimal.TryParse(Console.ReadLine(), out output);
                if (isValidDecimal && hasRange==true)
                {
                    if(output<=maxValue && output >= minValue)
                    {
                        isInRange = true;
                    }
                }
            }
            return output;
        }

        public static string RequestString(this string message){
            string output = "";
            if (string.IsNullOrWhiteSpace(output))
            {
                Console.WriteLine(message);
                 output = Console.ReadLine();
            }
            return output;
        }
        public static int RequestInteger(this string message, int minValue, int maxValue)
        {
            return message.RequestInteger(true,minValue,maxValue);
        }
        public static int RequestInteger(this string message)
        {
            return message.RequestInteger(false);
        }
            
        private static int RequestInteger(this string message,bool useMinMax, int minValue=0, int maxValue=0)
        {
            int output = 0;
            bool isValidInt = false;
            bool isInValidRange = true;
            if (output == 0)
            {
                while (isValidInt == false||isInValidRange==false)
                {
                    Console.WriteLine(message);

                    isValidInt = int.TryParse(Console.ReadLine(), out output);
                    if (useMinMax)
                    {
                        if (output >= minValue && output <= maxValue)
                        {
                            isInValidRange = true;
                        }
                        else
                        {
                            isInValidRange=false;
                        }
                    }
                }
            }
            return output;
        }

        
    }
}
