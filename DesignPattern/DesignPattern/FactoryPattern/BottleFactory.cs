using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.FactoryPattern
{
    internal class BottleFactory
    {
        public BottleFactory(string Type, int Amount)
        {
            if(Type == "Glass")
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
}
