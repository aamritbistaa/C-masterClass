using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security;
using System.Text;
using System.Threading.Tasks;

// Enum are sealed class

namespace Test
{
    public static class OOPHelpers
    {
        public static DateOnly ReturnCurrentDate()
        {
            DateTime today = DateTime.Today;
            var todayDate = today.ToShortDateString();
            return DateOnly.Parse(todayDate);
        }
        
    }
    public abstract class LivingThing
    {

        protected string? Name { get; set; }
        protected DateOnly Dob { get; set; }

        public LivingThing()
        {
            Console.WriteLine("Living thing is born");
        }
        public virtual void Walk()
        {
            Console.WriteLine("Living thing is walking");
        }
        public virtual void Eat()
        {
            Console.WriteLine("Eating item");
        }
        public virtual void Eat(bool IsCooked)
        {
            if (IsCooked) Console.WriteLine("Eating cooked item");
        }
        public abstract void Evolve();
        public string hello;
    }

    public class Human: LivingThing
    {
        private bool IsMarried { get; set; } = false;
        public List<string> Child = new List<string>();

        //Default Constructor
        //THis will call base class first then there
        public Human() : base()
        {
            Console.WriteLine("Living thing is Human");
            Dob = OOPHelpers.ReturnCurrentDate();
        }
        //Parameterized Constructor
        //overloading
        public Human(string Name)
        {
            this.Name = Name;
        }
        public Human(string Name, DateOnly Dob)
        {
            this.ChangeDOB(Dob);
            this.ChangeName(Name);
            this.Dob = Dob;
        }
        protected void ChangeDOB(DateOnly Dob)
        {
            this.Dob = Dob;
        }
        public void ChangeName(string name)
        {
            this.Name = name;
        }
        public void PrintDetails()
        {
            Console.WriteLine($"{Name} born on {Dob}, Is married: {IsMarried}");
        }

        
        public override sealed void Walk()
        {
            base.Walk();
            Console.WriteLine("Human is walking ");
        }
        public override sealed void Eat()
        {
            base.Eat();
            Console.WriteLine("Human is eating");
        }
        public override void Evolve()
        {
            Console.WriteLine("Human is evolving");
        }
    }
    public class NorthAmerican : Human
    {
        public void ChangeDOB(DateOnly date)
        {
            base.ChangeDOB(date);
        }
    }
    internal class OOP
    {
        
        protected void TempFunction()
        {
            NorthAmerican southPerson = new NorthAmerican();
            southPerson.ChangeDOB(new DateOnly(2001, 11, 21));

        }

        public void MainFunction()
        {
            //Copy Constructor
            //Human human1 = new Human("Shyam");
            //Human human2 = human1;

            //human1.PrintDetails();//Shyam
            //human2.PrintDetails();//Shyam
            //human1.ChangeName("Ram");
            //human1.PrintDetails();//Ram
            //human2.PrintDetails();//Ram
            //human2.ChangeName("Ramesh");
            //human1.PrintDetails();//Ramesh
            //human2.PrintDetails();//Ramesh

            //human1.PrintDetails();
            //human1.Walk();
            

            Human NorthAmericanPerson = new Human();
            NorthAmericanPerson.Eat();
            NorthAmericanPerson.Walk();
            //NorthAmericanPerson.ChangeDOB(new DateOnly(2001, 11, 21));
            TempFunction();




        }
    }
}
