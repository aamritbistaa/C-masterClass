using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework___Abstract_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KantipurEngineeringCollege college = new KantipurEngineeringCollege();
            college.Location = "Dhapakhel";
            college.UniversityName = "Tribhuvan University";
            List<IUniversity> universitiesProperty = new List<IUniversity>();

            universitiesProperty.Add(college);

            foreach(var item in  universitiesProperty )
            {
                Console.WriteLine(item.UniversityName);
                //------this cant be shown because, we are iterating over list of type interface and interface doesnot has the property Location
                //Console.WriteLine(item.Location);
            }

            Console.ReadLine();

        }
    }

    public interface IUniversity
    {
        string UniversityName { get; set; }
    }
    public abstract class University : IUniversity
    {
        public string UniversityName { get; set; }
    }
    public abstract class IOE : University
    {

    }

    public class KantipurEngineeringCollege : IOE
    {
        public string Location { get; set; }
    }
}
