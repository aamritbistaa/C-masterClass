using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> listString = new List<string>();
            List<int> listInt = new List<int>();
            Console.WriteLine(FizzBuzz("Ramesh"));
            Console.WriteLine(FizzBuzz(123123));
            Console.WriteLine(FizzBuzz(12356));
            Console.WriteLine(FizzBuzz("abcdefghijklmno"));
            PersonModel per = new PersonModel();
            per.FirstName = "Amrit";
            per.LastName = "Bista";
            //per goes as Generics.PersonModel
            Console.WriteLine(FizzBuzz(per));
            GenericHelper<PersonModel> peop = new GenericHelper<PersonModel>();
            peop.CheckItemAndAdd(new PersonModel {FirstName="Amr",LastName="Bis",HasError=true });

            foreach(var item in peop.RejectedItems)
            {
                Console.WriteLine("Rejected Item");
                Console.WriteLine(item.FirstName);
            }
            foreach (var item in peop.Items)
            {
                Console.WriteLine("Accepted Item");
                Console.WriteLine(item.FirstName);
            }

            Console.ReadLine();
        }
        public static void Homework<T>(T input)
        {
            Console.WriteLine(input.ToString());
        }
        private static string FizzBuzz<T>(T input)
        {
            //Display Fizz or Buzz based on length of input
            //divisible by 3-fizz
            //divisible by 5-Buzz
            //divisible by 3&5 fizzbuzz
            string output = "";
            int length = input.ToString().Length;
            if (length % 3 == 0)
            {
                output = output + "Fizz";
            }
            if(length % 5 == 0) {

                output = output + "Buzz";
            }
            if(length%3!=0 || length%5 != 0)
            {
                return length.ToString();
            }
            return output;
        }
    }

    //where T must be class that implements IErrorCheck interface
    public class GenericHelper<T> where T: class, IErrorCheck
    {
        public List<T> Items { get; set; }
        public List<T> RejectedItems { get; set; }

        public void CheckItemAndAdd(T item)
        {
            if (item.HasError == false)
            {
                Items.Add(item);
            }
            else
            {
                RejectedItems.Add(item);
            }
        }
    }
    public interface IErrorCheck
    {
        string Manufacturer { get; set; }
        int YearManufactured { get; set; }
        bool HasError { get; set; }
    }

    public class PersonModel : IErrorCheck
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HasError { get; set; }
        string IErrorCheck.Manufacturer { get; set; }
        int IErrorCheck.YearManufactured { get; set; }
    }
}
