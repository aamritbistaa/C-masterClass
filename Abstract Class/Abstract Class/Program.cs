using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Manufacturer = "Ford";
            car.Model = "Raptor";
            car.ProductName = "Ford Raptor 2021";
            car.Quantity = 20;
            car.NoOfWheel = 6;

            Console.ReadLine();
        }
    }
    public abstract class InventoryItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
    public class Book :InventoryItem
    {

    }
    public abstract class Vehicle : InventoryItem
    {
        public string VIN { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
    }
    public class Car : Vehicle
    {
        public int NoOfWheel { get; set; }
    }
}

//Abstract Class are the class whose instance cant be create
