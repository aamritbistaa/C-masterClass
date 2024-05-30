using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework___Mini_project_Generic_and_Event
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<PersonModel> Persons = new List<PersonModel> { 
            new PersonModel { FirstName="Amrit", LastName="Bista", Email="aamritbistaa@gmail.com"},
            new PersonModel { FirstName="asd", LastName="asd", Email="asd@gmail.com"},
            new PersonModel { FirstName="das", LastName="das", Email="das@gmail.com"},
                        new PersonModel { FirstName="", LastName="das", Email="das@gmail.com"}

            };
            List<CarModel> Cars = new List<CarModel> { new CarModel{Manufacturer="Ford", Model="Raptor"},
                 new CarModel{Manufacturer="Ford", Model="Ranger"},
                 new CarModel{Manufacturer="Ford", Model="Everest"},
                 new CarModel{Manufacturer="Ford", Model="Ecosport"},
            };
            string currentDirectory = Environment.CurrentDirectory.Substring(0,Environment.CurrentDirectory.Length-10);
            
            string fileLocation = Path.Combine(currentDirectory, @"SavedData\");

            DataAccess<PersonModel> peopleData = new DataAccess<PersonModel>();
            peopleData.BadEntryFound += PeopleData_BadEntryFound;
            peopleData.SaveToCsv(Persons,$"{fileLocation}\\persons.csv");

            DataAccess<CarModel> carData = new DataAccess<CarModel>();
            carData.BadEntryFound += CarData_BadEntryFound;
            carData.SaveToCsv(Cars,$"{fileLocation}\\Cars.csv");

            Console.ReadLine();
        }

        private static void CarData_BadEntryFound(object sender, CarModel e)
        {
            Console.WriteLine($"Bad entry found data: Mnufacturer: {e.Manufacturer}, Model: {e.Model}");
        }

        private static void PeopleData_BadEntryFound(object sender, PersonModel e)
        {
            Console.WriteLine($"Bad entry found data: FirstName: {e.FirstName}, LastName: {e.LastName}");
        }
    }
    public class DataAccess<T> where T: new()
    {
        public event EventHandler<T> BadEntryFound;

        //extension method 
        //Here T or generic is not the function, but it is the item we are passing, which may be CarModel or PersonModel
        //T has to have the empty object of those type
        //public static void SaveToCsv<T>(this List<T> items, string filePath) where T : new()

        //A extension method that returns nothing, but takes file path as input, also takes generic type of list of items
        public void SaveToCsv(List<T> items, string filePath)

        {
            List<string> rows = new List<string>();
            T entry = new T();
            string row = "";
            //To find the data type or column type
            var cols = entry.GetType().GetProperties();
            foreach(var col in cols)
            {
                row += $",{col.Name}";
            }
            row = row.Substring(1);
            rows.Add(row);
            //Extracts record from the list
            foreach(var item in items)
            {
                row = "";
                bool badWord = false;
               //Column has the property
                foreach (var col in cols)
                {
                    string val = col.GetValue(item).ToString();
                    badWord = BadWordDetector(val);
                    if (BadWordDetector(val) == true)
                    {
                        BadEntryFound?.Invoke(this, item);
                        //if detected it will exit out of this for each loop
                        break;
                    }
                    row += $",{col.GetValue(item)}";
                }
                if (badWord == true)
                {
                    //if detected, it will skip the bottom process and run for another value of column
                    continue;
                }
                row = row.Substring(1);
                rows.Add(row);
            }
            File.WriteAllLines(filePath, rows);
        }
        private static bool BadWordDetector(string stringToTest)
        {
            bool output = false;
            string lowerCaseTest = stringToTest.ToLower();
            if (lowerCaseTest.Trim() == "")
            {
                output = true;
            }
            //if (lowerCaseTest.Contains("darn") || lowerCaseTest.Contains("heck"){
            //    output = true;
            //}
            return output;
        }
    }
    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
       

    }
    public class CarModel
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }

    }
}
