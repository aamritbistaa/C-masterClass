using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Corolla corollaCar = new Corolla();
            corollaCar.StartCar();
            corollaCar.NumberOfWheels = 4;
            
            SmartPhone phone = new SmartPhone();
            phone.Carrier = "ATNT";
            phone.Apps.Add("Facebook");

            LandLine landLine = new LandLine();
            landLine.PlaceCall();
            landLine.StopCall();

            List<Phone> phoneList = new List<Phone>();
            phoneList.Add(new CellPhone());
            phoneList.Add(new SmartPhone());

            foreach(var item in  phoneList)
            {
                if(item is CellPhone cell)
                {
                    cell.Carrier = "";
                }
                if(item is SmartPhone smartPhone)
                {
                    smartPhone.ConnectToInternet();
                }
            }

            Console.ReadLine();
        }
    }

}