using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Homework_MiniProject___Guest_Book
{
    public static class GuestLogic
    {
        public static void Welcome()
        {
            Console.WriteLine("Welcome to the Guest Book App");
            Console.WriteLine();
        }
        public static string GetGroupName()
        {
            Console.WriteLine();
            Console.WriteLine("Enter Group name: ");
            string groupName;
            do
            {
                groupName = Console.ReadLine();
            } while (groupName.Trim() == "");
            return groupName;
        }

        public static int GetGroupSize()
        {
            int groupSizeNumber;
            bool isValidNumber;

            Console.WriteLine("How many people are in your group");
            do
            {
                string groupSizeText = Console.ReadLine();
                isValidNumber = int.TryParse(groupSizeText, out groupSizeNumber);
            } while (isValidNumber == false && !(groupSizeNumber>0));
            return groupSizeNumber;
        }

        public static bool AskToContinue()
        {
            Console.WriteLine("Are there more Guests (yes/no): ");
            //Console.WriteLine("yes by default");
            string choice = Console.ReadLine();

            if (choice.ToLower() == "no")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        public static (List<string> guests, int totalPeople) AddAllGuest()
        {
            int totalPeople = 0;

            List<string> guests = new List<string>();
            do
            {
                string groupName = GetGroupName();

                guests.Add(groupName);

                int groupSize = GetGroupSize();

                totalPeople += groupSize;

            } while (AskToContinue());

            return (guests, totalPeople);
        }

        public static void DisplayAllGuest(List<string> guestsNameList)
        {
            Console.WriteLine();
            Console.WriteLine("Displaying Groups: ");
            foreach (string guest in guestsNameList)
            {
                Console.WriteLine(guest);
            }
        }
        public static void DisplayGuestCount(int count)
        {
            Console.WriteLine();
            Console.WriteLine(
                $"The total no of people present in today's event is {count}");
        }
    }
}

