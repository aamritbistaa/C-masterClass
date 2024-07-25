using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.FactoryPattern
{
    internal class PlasticUnit : Bottle
    {
        public override void CreateBottle(int numberOfUnit)
        {
            Console.WriteLine($"Creating Plastic Bottles {numberOfUnit} times");
        }
    }
}
