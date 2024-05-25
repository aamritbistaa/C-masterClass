using GuestBookClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Capture Information about each guest
//FirstName, LastName, message to host
//Once done, loop through each guest and print their information
namespace ConsoleUI
{
    internal class Program
    {
        private static List<GuestModel> guests = new List<GuestModel>();

        static void Main(string[] args)
        {
            GetGuestInformation();

            DisplayGuestInformation();
            
            Console.ReadLine();
        }

        private static void DisplayGuestInformation() {
            foreach (GuestModel guest in guests)
            {
                Console.WriteLine(guest.GuestInfo);
            }
        }
        private static void GetGuestInformation()
        {
            string choice = "";
            do
            {
                GuestModel guest = new GuestModel();

                guest.FirstName = GetInfoFromConsole("Enter First Name");

                guest.LastName = GetInfoFromConsole("Enter Last Name");

                guest.MessageToHost = GetInfoFromConsole("Enter your message for the guest");

                guests.Add(guest);

                choice = GetInfoFromConsole("press y to add more ");
                Console.Clear();
            } while (choice.ToLower() == "y");
        }
        private static string GetInfoFromConsole(string message)
        {
            string output = "";
            Console.WriteLine(message);
            output= Console.ReadLine();
            return output;
        }
    }
}
