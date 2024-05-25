using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namespace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
            Namespace.PersonModel person = new PersonModel();
            person.Name = "ramesh";
            DifferentNamespace.Calculation.Add(5, 10);
            Console.ReadLine();
        }
    }
}
