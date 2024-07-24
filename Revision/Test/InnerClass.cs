using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{


    public abstract class Person
    {
        public Person()
        {
            Console.WriteLine("This is Default Person Constructor. ");
        }
        public Person(string name)
        {
            Console.WriteLine("This is Parameterized Constructor. ");
        }
    }
    public  class Student11:Person
    { 
        // while executing this default constructor, it calls the parent default constructor
        public Student11()
        {

        }
        // while executing this parameterized constructor, it calls the parent parameterized constructor
        public Student11(string name):base(name)
        {
            
        }
    }


    internal class InnerClass 
    {
        public void MainFunction()
        {
            Student11 obj = new Student11("Ramesh");
            Student11 obj1 = new Student11();
        }

    }
}
