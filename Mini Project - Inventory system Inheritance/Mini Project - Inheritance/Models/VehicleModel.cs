using System;

namespace Mini_Project___Inheritance
{
    public class VehicleModel : InventoryItemModel, IRentalable, IPurchaseable
    {
        public decimal DealerFee { get; set; }

        public void Purchase()
        {
            Quantity = Quantity - 1;
            Console.WriteLine("Vehicle has been purchased");
        }

        public void Rent()
        {
            Quantity = Quantity - 1;
            Console.WriteLine("Vehicle has been rented");
        }

        public void ReturnRentProperty()
        {
            Console.WriteLine($"{ProductName} Returned");
            Quantity = Quantity + 1;
        }
    }
    }
