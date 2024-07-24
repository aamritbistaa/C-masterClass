using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class PointerClass
    {
        private int sum;
        
        //constructor chaining
        public PointerClass() :this(0123)
        {
            
        }
        public PointerClass(int sum)
        {
            this.sum = sum;            
        }
        public void Display (PointerClass ptr)
        {
            Console.WriteLine(ptr.sum);
        }
        public void DisplaySum()
        {
            Console.WriteLine(sum);
        }
        public void Deposit(int amount)
        {
            sum = sum + amount;
        }
        public void Withdraw(int amount)
        {
            sum = sum - amount;
        }


        public void MainFunction()
        {
            
            this.DisplaySum();
            this.Deposit(1000);
            this.DisplaySum();
            this.Withdraw(100);
            this.DisplaySum();
            Display(this);
        }

        private string[] days = new string[7]; // Assuming days is an array of strings

        private string[] months = new string[7]; // Assuming days is an array of strings

        public string this[int index]
        {
            get
            {
                return months[index];
                return days[index];            }

            set
            {
                months[index] = value;
                days[index] = value;
            }
        }

    }

    internal class ThisPointer
    {
        public void MainFunction()
        {
            PointerClass obj = new PointerClass(0987);
            obj.MainFunction();
            obj[0] = "Monday";
            obj[1] = "Tuesday";

            // Getting values using the indexer
            string day1 = obj[0]; // day1 will be "Monday"
            string day2 = obj[1];

            Console.WriteLine(day1);
        }
    }
}
