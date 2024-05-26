using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project___Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<InventoryItemModel> inventory = new List<InventoryItemModel>();

            var vehicle = new VehicleModel { DealerFee = 20, ProductName = "Ford Raptor" , Quantity =10};
            var book = new BookModel { ProductName = "Tim Cook", NumberOfPages = 220, AuthorName = "Leander Kahney", Quantity = 20 };
            var excavator = new ExcavatorModel { ProductName = "Cat Bulldozer", Quantity = 5 };

            List<IRentalable> rentable = new List<IRentalable>();
            rentable.Add(vehicle);
            rentable.Add(excavator);
            List<IPurchaseable> purchasable = new List<IPurchaseable>();
            purchasable.Add(book);
            purchasable.Add(vehicle);
            //purchasable.Add(excavator); error - excavator is only rentable


            Console.WriteLine("Do you want to add or purchase: (rent | purchasable)");
            string choice = Console.ReadLine();

            if (choice.ToLower() == "rent")
            {
                foreach(var item in rentable) {
                    Console.WriteLine($"Item: {item.ProductName}");
                    Console.WriteLine("Conform your rental (yes/no): ");
                    string wantToRent = Console.ReadLine();
                    if (wantToRent.ToLower() == "yes")
                    {
                        item.Rent();
                    }
                    Console.WriteLine("Conform your rental (yes/no): ");
                    string wantToReturn = Console.ReadLine();
                    if (wantToReturn.ToLower() == "yes")
                    {
                        item.ReturnRentProperty();
                    }
                }
            }
            else
            {
                foreach (var item in purchasable)
                {
                    Console.WriteLine($"Item: {item.ProductName}");
                    Console.WriteLine("Conform your purchase (yes/no): ");
                    string wantToPurchase = Console.ReadLine();
                    if (wantToPurchase.ToLower() == "yes")
                    {
                        item.Purchase();
                    }
                }
            }
            Console.ReadLine();
        }


    }
    }
