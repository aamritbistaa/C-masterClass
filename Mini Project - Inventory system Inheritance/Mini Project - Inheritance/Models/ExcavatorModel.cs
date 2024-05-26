using System;

namespace Mini_Project___Inheritance
{
    public class ExcavatorModel : InventoryItemModel, IRentalable
    {
        public void Dig()
        {
            Console.WriteLine("Digging....");
        }

        public void Rent()
        {
            Console.WriteLine("Renting the excavator....");
            Quantity = Quantity - 1;
        }

        public void ReturnRentProperty()
        {
            Console.WriteLine("Excavator Returned");
            Quantity = Quantity + 1;
        }

        public void Stop()
        {
            Console.WriteLine("Haulting.....");
        }
    }
    }
