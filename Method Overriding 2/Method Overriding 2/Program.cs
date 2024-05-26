using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Method_Overriding_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tesla tesla = new Tesla();
            Console.WriteLine( tesla.ToString());
            Console.ReadLine();
        }

    }
    public abstract class Car
    {
        public virtual void StartCar()
        {
            Console.WriteLine("Starting");
        }
        internal abstract void SetClock();
    }
    public class Corolla : Car
    {
        internal override void SetClock()
        {
            Console.WriteLine("Corolla clock");
        }
    }

    public class Tesla : Car
    {
        public override void StartCar()
        {
            Console.WriteLine("Input the destination");
        }
        internal override void SetClock()
        {
            Console.WriteLine("Connect to internet");
        }
        public override string ToString()
        {
            return "Tesla to string method overridden";
        }
    }
}
