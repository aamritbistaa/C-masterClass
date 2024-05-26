using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework___Interface
{
    //Create a IRun interface and apply it to Person class and an Animal class. store both types in a list<IRun> object.
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IRun> livingThing = new List<IRun>();

            Person person = new Person();
            person.Name = "Ram";
            livingThing.Add(person);

            Animal animal = new Animal();
            animal.Name = "dog";
            livingThing.Add(animal);


            foreach (IRun r in livingThing)
            {
                if(r is Person p)
                {
                    Console.WriteLine($"Person {p.Name}");
                    p.Run();
                    
                }
                if (r is Animal a)
                {//created a to be free from protection that r cant access
                    Console.WriteLine($"Animal {a.Name}");
                    a.Run();

                }
            }

            Console.ReadKey();
        }
    }

    public interface IRun
    {
        void Run();
    }

    public class Person : IRun
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void Run()
        {
            /*
             * Random rn = new Random();
             * rn.Next(1,20);
             */
            Console.WriteLine($"A man, {Name} is running at {new Random().Next(1, 20)} km/h");            
        }
    }
    public class Animal : IRun
    {
        public string Name { get; set; }

        public void Run()
        {
            Random rn = new Random();
            Console.WriteLine($"A {Name} is running at {rn.Next(1, 20)} km/h");
        }
    }
}
