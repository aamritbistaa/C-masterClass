using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.FactoryPattern
{
    internal class GlassUnit : Bottle
    {
        public override void CreateBottle(int numberOfUnit)
        {
            Console.WriteLine($"Creating Glass Bottles {numberOfUnit} times");
        }
    }
}
