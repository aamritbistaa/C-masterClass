using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework___Inheritance
{

    //Create a vehicle class, a car class, a boat class, and a motorcycle class. Identify what inheritance should happen, if any, and  wire it up.
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles.Add(new Car { HasWheels = true, HasAc = true });
            vehicles.Add(new Motorcycle());
            Console.ReadLine();
        }
    }
    public class Vehicle
    {
        public bool HasWheels { get; set; }
        
        public void StartTheEngine()
        {

        }
    }
    public class Car:Vehicle
    {
        public bool HasAc { get; set; }
    }
    public class Boat:Vehicle
    {
        public bool CanFloat { get; set; }
    }
    public class Motorcycle:Vehicle
    {

    }
}
