using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Student1
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Subjects { get; set; }
    }
    internal class Test1
    {

        public void MainFunction()
        {

        List<Student1> listOfStudents = new List<Student1>
        {
            new Student1 { Name = "Alice", Age = 20, Subjects = "Math" },
            new Student1 { Name = "Bob", Age = 22, Subjects = "Physics" },
            new Student1 { Name = "Charlie", Age = 21, Subjects = "Math" },
            new Student1 { Name = "David", Age = 20, Subjects = "Physics" },
            new Student1 { Name = "Eve", Age = 22, Subjects = "Math" }
        };

            var outerCollection = new List<List<int>>
{
new List<int> { 1, 2, 3 },
new List<int> { 4, 5 },
new List<int> { 6, 7, 8, 9 }
};

            var listOfListOfNumber = outerCollection.Select(c => c);

            var flattenedCollection = outerCollection.SelectMany(innerList => innerList);

            //var dictionaryOfStudent = listOfStudents.ToDictionary(x => x.Name, x => x.Subjects);
            //var dictionaryOfStudent = listOfStudents.ToDictionary(x => x.Name, x => x);

            //var studentName = listOfStudents.Select(x => x.Subjects).ToList();
            //var selectStudent = listOfStudents.SelectMany(x => x.Subjects).ToList();

            //foreach (var item in listOfStudents)
            //{
            //    Console.WriteLine(item.Key);
            //    Console.WriteLine($"{item.Value.Name},{item.Value.Subjects},{item.Value.Subjects}");
            //}

        }
    }
}
