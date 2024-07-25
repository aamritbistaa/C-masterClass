using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.FactoryPattern
{
    internal class MetalUnit : Bottle
    {
        public override void CreateBottle(int n)
        {
            Console.WriteLine($"Creating Metal Bottle {n} times");
        }
    }
}
