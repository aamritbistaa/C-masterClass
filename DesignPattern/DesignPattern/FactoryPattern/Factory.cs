using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.FactoryPattern
{
    public abstract class Bottle
    {
        public abstract void CreateBottle(int numberOfUnit);
    }
    internal class GlassUnit : Bottle
    {
        public override void CreateBottle(int numberOfUnit)
        {
            Console.WriteLine($"Creating Glass Bottles {numberOfUnit} times");
        }
    }
    internal class MetalUnit : Bottle
    {
        public override void CreateBottle(int n)
        {
            Console.WriteLine($"Creating Metal Bottle {n} times");
        }
    }
    internal class PlasticUnit : Bottle
    {
        public override void CreateBottle(int numberOfUnit)
        {
            Console.WriteLine($"Creating Plastic Bottles {numberOfUnit} times");
        }
    }
    internal class BottleFactory
    {
        public BottleFactory(string Type, int Amount)
        {
            if (Type == "Glass")
            {
                var obj = new GlassUnit();
                obj.CreateBottle(Amount);
            }
            else if (Type == "Metal")
            {
                var obj = new MetalUnit();
                obj.CreateBottle(Amount);
            }
            else if (Type == "Plastic")
            {
                var obj = new PlasticUnit();
                obj.CreateBottle(Amount);
            }
            else
            {
                throw new Exception("Type you entered is invalid");
            }
        }
    }

    internal class FactoryImplementation
    {
        public void Main()
        {
            BottleFactory obj = new BottleFactory("Metal", 200);
        }
    }
}
