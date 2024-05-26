using System;

namespace Mini_Project___Inheritance
{
    public class BookModel : InventoryItemModel, IPurchaseable
    {
        public int NumberOfPages { get; set; }
        public string AuthorName { get; set; }

        public void Purchase()
        {
            Quantity = Quantity - 1;
            Console.WriteLine("Book has been purchased");
        }
    }
    }
