using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    internal class Program
    {
        //Event helps to know something has changed
        //Can inturrupt the running action and fire in the middle of some action
        static void Main(string[] args)
        {
            CollegeClassModel Physics = new CollegeClassModel("Physics 101", 5);
            CollegeClassModel Calculus = new CollegeClassModel("Calculus 101", 3);
            //----------Event Listner---------
            //Physics.EnrollmentFull += Physics_EnrollmentFull;
            Physics.EnrollmentFull += College_EnrollmentFull;


            Physics.SignUpStudent("Ramesh").PrintToConsle();
            Physics.SignUpStudent("Prakash").PrintToConsle();
            Physics.SignUpStudent("Subash").PrintToConsle();
            Physics.SignUpStudent("Harish").PrintToConsle();
            Physics.SignUpStudent("Ram").PrintToConsle();
            Physics.SignUpStudent("Rame").PrintToConsle();

            //Calculus.EnrollmentFull += Calculus_EnrollmentFull;
            Calculus.EnrollmentFull += College_EnrollmentFull;


            Calculus.SignUpStudent("Subash").PrintToConsle();
            Calculus.SignUpStudent("Harish").PrintToConsle();
            Calculus.SignUpStudent("Ram").PrintToConsle();
            Calculus.SignUpStudent("Rame").PrintToConsle();
            Console.ReadLine();
        }

        private static void College_EnrollmentFull(object sender, string e)
        {
            CollegeClassModel model = (CollegeClassModel)sender;
            Console.WriteLine(model.CourseTitle);
            Console.WriteLine(e);
        }

        //private static void Calculus_EnrollmentFull(object sender, string e)
        //{
        //    Console.WriteLine("Enrollment is full for Calculus");
        //}

        //private static void Physics_EnrollmentFull(object sender, string e)
        //{
        //    Console.WriteLine("Enrollment is full for Physics");
        //}
    }

    public static class ClassHelpers
    {
        public static void PrintToConsle(this string message)
        {
            Console.WriteLine(message);
        }
    }

    public class CollegeClassModel
    {
        //----------Event Decleration----------
        public event EventHandler<string> EnrollmentFull;

        private List<string> enrolledStudents = new List<string>();
        private List<string> waitingStudents = new List<string>();
        public string CourseTitle { get; private set; }
        public int MaximumStudent { get; private set; }

        public CollegeClassModel(string title, int maximumStudent)
        {
            CourseTitle = title;
            MaximumStudent = maximumStudent;

        }
        public string SignUpStudent(string studentName)
        {
            string output = "";
            if (enrolledStudents.Count < MaximumStudent)
            {
                enrolledStudents.Add(studentName);
                output = $"{studentName} was enrolled to {CourseTitle}";
                if (enrolledStudents.Count == MaximumStudent)
                {

                //--------Event triggerer---------

                EnrollmentFull?.Invoke(this, $"{CourseTitle} enrollment is full");

                }
            }
            else
            {
                waitingStudents.Add(studentName);
                output = $"{studentName} was added to waiting list for {CourseTitle}";

            }
            return output;
        }

    }
}
