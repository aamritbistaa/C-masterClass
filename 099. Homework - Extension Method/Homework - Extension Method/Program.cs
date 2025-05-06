using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Homework___Extension_Method
{
    internal class Program
    {
        //TO create chain
        //person.SetDefaultAge().PrintInfo()
        static void Main(string[] args)
        {
            Person person = new Person();
            person.SetDefaultAge().PrintInfo();
            person.SetAge(30).PrintInfo();
            Console.ReadLine();
        }
    }
    public class Person
    {
        public int Age { get; set; }

    }
    public static class Extensions
    {
        public static Person SetDefaultAge(this Person p)
        {
            p.Age = 20;
            return p;
        }
        public static Person PrintInfo(this Person p)
        {
            Console.WriteLine($"{p.Age}");
            return p;
        }

        public static Person SetAge(this Person p,int age)
        {
            p.Age = age;
            return p;
        }
    }

}
