using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;
using System.Threading.Tasks;
using static Test.JoinClass;

namespace Test
{


    ///
    //  public class Linq
    // {

    //     string[] name = { "Ram", "Shyam", "Ramesh", "Hari" };
    //     List<string> nameList = new List<string>();

    //     public class StudentModel
    //     {
    //         public string Name { get; set; }
    //         public int Age { get; set; }

    //         public List<string> Subjects = new List<string>();
    //         public bool IsActive { get; set; }

    //     }
    //     List<StudentModel> students = new List<StudentModel>
    //     {
    //         new StudentModel
    //         {
    //             Name = "Amrit",
    //             Age = 13,
    //             Subjects =["Physics", "Math"],
    //             IsActive = true
    //         },
    //         new StudentModel
    //         {
    //             Name = "Hari",
    //             Age = 23,
    //             Subjects =["Bio", "Physics"],
    //             IsActive = false
    //         },
    //         new StudentModel
    //         {
    //             Name = "Amrit213",
    //             Age = 33,
    //             Subjects =["Zoology", "Physics"],
    //             IsActive = true
    //         },
    //         new StudentModel
    //         {
    //             Name = "Amri1i2u3t",
    //             Age = 0213,
    //             Subjects =["Astronomy", "Physics"],
    //             IsActive = false
    //         }

    //     };


    //     public void MainFunction()
    //     {
    //         Console.WriteLine(name[-1]);

    //         var queryStartingWithR = from item in name
    //                                  where item.StartsWith("R")
    //                                  select item;
    //         Console.WriteLine("Printing names starting with R");
    //         foreach (var item in queryStartingWithR)
    //         {
    //             System.Console.WriteLine(item);
    //         }
    //         var queryHavingLengthMoreThan5 = from item in name
    //                                          where item.Length > 5
    //                                          select item;

    //         /*
    //         var item1 = queryHavingLengthMoreThan5.ToImmutableArray();
    //         Console.WriteLine(item1[0]);
    //         */

    //         Console.WriteLine("Printing names length more than 5");
    //         foreach (var item in queryHavingLengthMoreThan5)
    //         {
    //             Console.WriteLine(item);
    //         }

    //         var queryOverObject = from item in students
    //                               where item.Age > 30 || item.Subjects.Contains("Bio") || item.IsActive == true
    //                               select item;

    //         foreach (var item in queryOverObject)
    //         {
    //             Console.WriteLine($"{item.Name}, {item.Age}");
    //             foreach (var item1 in item.Subjects)
    //             {
    //                 Console.WriteLine(item1);
    //             }
    //         }

    //         //* Lamda + Linq Method
    //         var ascendingSortedStudentModel = students.OrderBy(item => item.Age);
    //         var descendingSortedStudentModel = students.OrderByDescending(item => item.Age);
    //         var studentsHavingAgeMoreThan30 = students.FindAll(x => (x.Age > 30) || x.Subjects.Contains("Bio") || (x.IsActive == true));
    //         var nameOfStudent = students.Select(x => x.Name);

    //         //* Expression Lambda -> Containing a single expression in lambda body
    //         var sum = (int a, int b) => a + b;

    //         Console.WriteLine(sum(10, 20));


    //         //* Statement Lambda -> Containing one or more expression in lambda body
    //         var multiplication = (int a, int b) =>
    //         {
    //             return a * b;
    //         };
    //         Console.WriteLine(multiplication(20, 5));

    //         //* LambdaExpression with Delegate
    //         Func<int, int> MultiplyBy3 = x => x * 3;

    //         Console.WriteLine(MultiplyBy3(3));

    //     }
    // }

    ///


    /*
        Linq can be written in two ways
            Query Syntax
                from [item] in [collection]
                where [condition]
                select [item]

            Method Syntax
            
    {               [collection].{methodName}(x=>x.Id==Id);

    */


    public class Subjects
    {
        public Guid SubjectId { get; set; } = Guid.NewGuid();
        public string SubjectName { get; set; }
        public Department DepartmentName { get; set; }
    }
    public enum Department
    {
        Science,
        Management,
        General,
        ComputerScience
    };

    public class Student
    {
        public Guid StudentId { get; set; } = Guid.NewGuid();
        public string StudentName { get; set; }
        public List<Subjects> Subjects { get; set; }
        public int Age { get; set; }
    }

    public class GenericCLass<T>
    {
        private T MyProperty { get; set; }
        public GenericCLass(T variable)
        {
            MyProperty = variable;
        }
        public void Disply()
        {
            Console.WriteLine(MyProperty);
        }
    }


    public class LinqImplementation
    {

        public static List<Subjects> listOfSubject = new List<Subjects>{
            new Subjects{
                SubjectName = "Foundation of OOP",
                DepartmentName = Department.ComputerScience
            },
            new Subjects{
                SubjectName = "Introduction to Networking",
                DepartmentName = (Department) 3
            },
            new Subjects{
                SubjectName = "Account",
                DepartmentName = Department.Management
            },
            new Subjects{
                SubjectName = "Finance",
                DepartmentName = Department.Management
            },
            new Subjects{
                SubjectName = "Cooking",
                DepartmentName = Department.General
            },
            new Subjects{
                SubjectName = "Physics",
                DepartmentName = Department.Science
            },
            new Subjects{
                SubjectName = "Calculus",
                DepartmentName = Department.Science
            }

        };
        public static List<Student> listOfStudent = new List<Student>
        {
            new Student
            {
                StudentName = "Student1",
                Subjects = new List<Subjects>{listOfSubject[2],listOfSubject[3] },
                Age =19
                },
            new Student
            {
                StudentName = "Student3",
                Subjects = new List<Subjects>{listOfSubject[4] },
                Age = 21
                },
            new Student
            {
                StudentName = "Student2",
                Subjects = new List<Subjects>{ listOfSubject[1], listOfSubject[2] },
                Age = 20
                },

            new Student
            {
                StudentName = "Student4",
                Subjects = new List<Subjects>(),
                Age = 20
                },
        };

        public void LinqWithMethod()
        {
            var SubjectsUnderManagement = listOfSubject
                                                    .Where(x => x.DepartmentName == Department.Management)
                                                    .Select(x => (x.SubjectName, x.SubjectId));
        }


        public void Where()
        {
            var SubjectsUnderManagement = from item in listOfSubject
                                          where item.DepartmentName == Department.Management
                                          select item.SubjectName;

            var studentEnrolledInNetworking = from item in listOfStudent
                                              where item.Subjects.Contains(listOfSubject[1])
                                              select item;

        }

        public void GroupAndOrder()
        {
            var groupedStudent = from item in listOfStudent
                                 orderby item.Age
                                 group item by item.Age;

            var groupedStudent1 = listOfStudent.OrderBy(x => x.Age).GroupBy(x => x.Subjects);

            var sortedInAscendingOrderStudentWithSomeQuery = from item in listOfStudent
                                                             orderby item.Age
                                                             select item;


            var sortedInDesccendingOrderStudentWithSomeQuery = from item in listOfStudent
                                                               orderby item.Age descending
                                                               select item;

        }
        public void LinqWithQuery()
        {




            var averageStudentAge = listOfStudent.Average(x => x.Age);
            var totalNumberOfStudent = listOfStudent.Count();



        }





    }



    public class Linq
    {
        public class Subjects
        {
            public Guid SubjectId { get; set; } = Guid.NewGuid();
            public string SubjectName { get; set; }
            public Department DepartmentName { get; set; }
        };
        public enum Department
        {
            Science,
            Management,
            General,
            ComputerScience
        };

        public static List<Subjects> listOfSubject = new List<Subjects>{
            new Subjects{
                SubjectName = "Foundation of OOP",
                DepartmentName = Department.ComputerScience
            },
            new Subjects{
                SubjectName = "Introduction to Networking",
                DepartmentName = (Department) 3
            },
            new Subjects{
                SubjectName = "Account",
                DepartmentName = Department.Management
            },
            new Subjects{
                SubjectName = "Finance",
                DepartmentName = Department.Management
            },
            new Subjects{
                SubjectName = "Cooking",
                DepartmentName = Department.General
            },
            new Subjects{
                SubjectName = "Physics",
                DepartmentName = Department.Science
            },
            new Subjects{
                SubjectName = "Calculus",
                DepartmentName = Department.Science
            }
        };
        public void FindingElement()
        {
            var listOfNum = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var listOfString = new List<int> { };
            var first = listOfNum.First(); //If list is empty this throws error
            var firstOrDefault = listOfNum.FirstOrDefault(); //Gives the first element or null, 0 [intger] in case of emptylist
            var firstOrDefString = listOfString.FirstOrDefault();

            var last = listOfNum.Last(); //If list is empty this throws error
            var lastOrDefault = listOfNum.LastOrDefault(); // Gives the last element or null, 0 [integer] in case of empty list

            var anyItem = listOfNum.Any(); //Gives boolean true/false, used to check if the list is empty or not

            var onlyOne = listOfNum.Find(x => (x + 1) >= x); //Return item from the list that matches the given condition.
            var all = listOfNum.FindAll(x => (x + 1) >= x); //Returns all the item from list that matches the given condition.

            var elementAt0 = listOfNum.ElementAt(0); //Returns item in 0th index or returns error if no element
            var elementAtNeg1 = listOfNum.ElementAt(-1); //throws error, negative index not supported
            var elementAt4 = listOfNum.ElementAtOrDefault(4); // returns item from specified index, index starts from 0
            var elementAt12 = listOfNum.ElementAt(12);

            //Return only one item that matches the condition, incase more than one matches the condition, this throws error.
            var foundItem = listOfNum.Single(x => x % 7 == 0);
            var singleItem = listOfNum.SingleOrDefault(x => x % 13 == 0);
        }

        public void ZipSequence()
        {

            List<int> listOfNumber = new List<int> { 1, 2, 3, 4 };
            List<string> listOfStrings = new List<string> { "First", "Second", "Third", "Fourth" };
            var newList = listOfNumber.Zip(listOfStrings);
            foreach (var item in newList)
            {
                Console.WriteLine($"{item.First} - {item.Second}");
            }
            var newNewList = listOfNumber.Zip(listOfStrings, (First, Second) => ( First +"-"+ Second));

            foreach (var item in newNewList)
            {
                Console.WriteLine(item);
            }
        }

        public void SetOperation()
        {
            List<int> list1 = new List<int> { 1, 2, 3 };
            List<int> list2 = new List<int> { 3, 4, 5, 6 };

            var list3 = list1.Concat(list2);
            var list4 = list1.Union(list2);
            var list5 = list1.Intersect(list2);
        }
        public void ContainDistinctExcept()
        {
            List<int> integerList = new List<int> { 1, 1, 34, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4 };
            bool result = integerList.Contains(10);
            var newList = integerList.Distinct();
            var listExcept10 = integerList.Except(new List<int> { 1 });
        }

        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Salary { get; set; }
        }
        public void MainFunction()
        {
            List<Employee> listEmployees = new List<Employee>
            {
                new Employee { ID= 1001, Name = "Priyanka", Salary = 80000 },
                new Employee { ID= 1002, Name = "Anurag", Salary = 90000 },
                new Employee { ID= 1003, Name = "Preety", Salary = 80000 }
            };

            var result = from emp in listEmployees
                         where emp.Salary == 80000
                         select emp;

            List<Employee> result2 = (from emp in listEmployees
                                           where emp.Salary >= 80000
                                           select emp).ToList();
            listEmployees.Add(new Employee { ID = 1004, Name = "Santosh", Salary = 80000 });

            // Adding a new employee with Salary = 80000 to the collection listEmployees
            result2.Add(new Employee { ID = 1004, Name = "Santosh", Salary = 80000 });


            foreach (var item in listEmployees)
            {
                Console.WriteLine(item.ID);
            }

            foreach (var item in result2)
            {
                Console.WriteLine(item.ID);
            }

            List<int> integerList = new List<int> { 1, 2, 3, 4, 5 };
            integerList.Prepend(10);
            integerList.Append(100);
            foreach (var integer in integerList)
            {

                Console.WriteLine(integer);

            }

            List<int> newnumberSequence = integerList.Append(100).Prepend(50).ToList();


            foreach (var integer in newnumberSequence)
            {

                Console.WriteLine(integer);

            }


            HashSet<int> s = new();
            s.Add(1);
            s.Add(1);
            s.Add(2);
            s.Add(3);
            s.Add(4);
            s.Add(5);
            foreach (var item in s)
            {
                Console.WriteLine(item);
            }

            List<Library> libraries = new List<Library>
            {
                new Library
                {
                    Id=1,
                    Name = "Library 1",
                    BookIds = [1,2,3]
                },
                new Library
                {
                    Id=2,
                    Name = "Library 2",
                    BookIds = [2,3,4,5]
                }
            };
            List<LibrarySingleBook> libraryAndSingleBook = new List<LibrarySingleBook>();
            int count = 0;
            foreach (var item in libraries)
            {
                foreach(var bok in item.BookIds)
                {
                    count++;
                    libraryAndSingleBook.Add(new LibrarySingleBook { Id = count, Name = item.Name, LibraryId=item.Id,BookId = bok});
                }
            }

            List<Book> books = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Name = "Physics"
                },
                new Book
                {
                    Id = 2,
                    Name = "Mathematics"
                },
                new Book
                {
                    Id = 3,
                    Name = "Computer Science"
                },
                new Book
                {
                    Id = 4,
                    Name = "Networking"
                },
                new Book
                {
                    Id = 5,
                    Name = "Account"
                },
                new Book
                {
                    Id = 6,
                    Name = "Finance"
                },
            };


            var data = from modifiedLibrary in libraryAndSingleBook
                       join book in books
                       on modifiedLibrary.BookId equals book.Id
                       select new
                       {
                           Id = modifiedLibrary.Id,
                           LibraryName = modifiedLibrary.Name,
                           BookName = book.Name
                       };

            foreach (var item in data)
            {
                Console.WriteLine($"{item.Id}: {item.LibraryName} {item.BookName}");
            }

            var query = (from library in libraries
                                    from bookId in library.BookIds
                                    join book in books on bookId equals book.Id
                                    select new
                                    {
                                        Id = library.Id,
                                        LibraryName = library.Name,
                                        BookId = bookId,
                                        BookName = book.Name
                                    }).ToList();

            foreach (var item in query)
            {
                Console.WriteLine($"{item.LibraryName}, {item.BookName}");

            }

            //var query = libraries.SelectMany(e => e.BookIds, (e, s) => new { e, s });


            //var datas = (from book in books
            //             join library in libraries on book.LibraryId equals library.Id
            //             select new LibraryBook()
            //             {
            //                 bookname = book.Name,
            //                 libname = library.Name
            //             }).ToList();



            //var query = (from library in libraries
            //             join book in books
            //             on library.BookIds equals book.Id
            //             select new Person()
            //             {
            //                 Id = library.Id,
            //                 Name = book.Name,
            //                 SubjectId = book.Id,
            //             }).ToList();



            List < ClassA > ClassAList = new List<ClassA>
            {
                new ClassA
                {
                    Id=1,
                    Name= "A - First"
                },
                new ClassA
                {
                    Id=2,
                    Name= "A - Second"
                },
                new ClassA
                {
                    Id=3,
                    Name= "A - Third"
                },
                new ClassA
                {
                    Id=4,
                    Name= "A - Third"
                },
            };
            List<ClassB> ClassBList = new List<ClassB>
            {
                new ClassB
                {
                    Id=1,
                    Name= "B - First",
                    ClassA_ID=1,

                },
                new ClassB
                {
                    Id=2,
                    Name= "B - Second",
                    ClassA_ID=2,
                },
                new ClassB
                {
                    Id=3,
                    Name= "B - Third",
                    ClassA_ID=3,

                },
                new ClassB
                {
                    Id=4,
                    Name= "B - Fourth",
                    ClassA_ID=3,

                },
            };
            List<ClassC> ClassCList = new List<ClassC>
            {
                new ClassC
                {
                    Id=1,
                    Name= "C - First",
                    ClassB_ID=1,

                },
                new ClassC
                {
                    Id=2,
                    Name= "C - Second",
                    ClassB_ID=2,
                },
                new ClassC
                {
                    Id=3,
                    Name= "C - Third",
                    ClassB_ID=3,
                },
                new ClassC
                {
                    Id=4,
                    Name= "C - Four",
                    ClassB_ID=2,
                },
            };

            var DataFromAB = from itemA in ClassAList
                             join itemB in ClassBList
                             on itemA.Id equals itemB.ClassA_ID
                             select new
                             {
                                 ClassAName = itemA.Name,
                                 ClassBName = itemB.Name,
                                 ClassBId = itemB.Id,
                             };

            var DataFromABC = from itemAB in DataFromAB
                              join itemC in ClassCList
                              on itemAB.ClassBId equals itemC.ClassB_ID
                              select new
                              {
                                  ClassAName = itemAB.ClassAName,
                                  ClassBName = itemAB.ClassBName,
                                  ClassCName = itemC.Name,
                              };
            var DataFromABCOnce = from itemA in ClassAList
                              join itemB in ClassBList
                              on itemA.Id equals itemB.ClassA_ID
                              join itemC in ClassCList
                              on itemB.Id equals itemC.ClassB_ID
                              select new
                              {
                                  itemAName = itemA.Name,
                                  itemBName = itemB.Name,
                                  itemCName = itemC.Name,
                              };

            foreach (var item in DataFromABCOnce)
            {
                Console.WriteLine($"{item.itemAName} {item.itemBName} {item.itemCName}");

            }

            foreach (var item in DataFromABC)
            {
                Console.WriteLine($"{item.ClassAName} {item.ClassBName} {item.ClassCName}");
            }
        }

    }

    public class LibrarySingleBook
    {
        public int Id { get; set; }
        public int LibraryId { get; set; }
        public string Name { get; set; }
        public int BookId { get; set; }

    }

    public class ClassA
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ClassB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassA_ID { get; set; }
    }
    public class ClassC
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassB_ID { get; set; }
    }

    public class LibraryBook
    {
        public string bookname { get; set; }
        public string libname { get; set; }
    }
    public class Library
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> BookIds { get; set; }  
    }
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Page
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
    public class JoinClass
    {
        public class Emp
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int EditedBy { get; set; }
        }
        public void SelfJoin()
        {

            List<Emp> empList = new List<Emp>
            {
                new Emp {
                    Id = 1,
                    Name = "Amrit",
                    EditedBy =2 },
                new Emp {
                    Id = 2,
                    Name = "Kanchan",
                    EditedBy =2 },
                new Emp {
                    Id = 3,
                    Name = "Suraj",
                    EditedBy =4},
                new Emp {
                    Id = 4,
                    Name = "HR",
                    EditedBy = 5}
                ,
                new Emp {
                    Id = 5,
                    Name = "TOP",
                    EditedBy =5 }
            };

            var query = from emp in empList
                        join e in empList
                        on emp.EditedBy equals e.Id
                        select new
                        {
                            Id = emp.Id,
                            Name = emp.Name,
                            Editor = e.Name
                        };
            foreach (var item in query)
            {
                Console.WriteLine($"{item.Id}: {item.Name} {item.Editor}");
            }



        }


        public void Joining3list()
        {
             List<Person> persons = new List<Person>
            {
                new Person
                {
                    Id = 1,
                    Name = "Ram",
                    SubjectId = 1,
                },
                new Person
                {
                    Id = 2,
                    Name = "Shyam",
                    SubjectId = 2,
                },
                new Person
                {
                    Id = 3,
                    Name = "Hari",
                    SubjectId = 1,
                },
                new Person
                {
                    Id = 4,
                    Name = "Pragyan",
                    SubjectId = 1,
                },
                new Person
                {
                    Id = 5,
                    Name = "Hari",
                },
            };
                List<Subject> subjects = new List<Subject>
            {
                new Subject
                {
                    Id= 1,
                    Name = "Physics"
                },
                new Subject
                {
                    Id= 2,
                    Name = "Finance"
                },
                new Subject
                {
                    Id= 3,
                    Name = "Account"
                },
            };
                //InnerJoin
                var itemInnerJoin = from p in persons
                                    join s in subjects
                                    on p.SubjectId equals s.Id
                                    select new
                                    {
                                        p.Id,
                                        Name = p.Name,
                                        Subject = s.Name,
                                    };
                // Person OuterJoin Subject
                var itemLeftJoin =
                                    from p in persons
                                    join s in subjects
                                    on p.SubjectId equals s.Id into gropedSubject
                                    from item in gropedSubject.DefaultIfEmpty()
                                    select new
                                    {
                                        Id = p.Id,
                                        Name = p.Name,
                                        Subject = item?.Name ?? "Subject is null"
                                    };
                // Subject OuterJoin Person
                var subjectLeftJoinPerson = from s in subjects
                                            join p in persons
                                            on s.Id equals p.SubjectId into groupedPersons
                                            from item in groupedPersons.DefaultIfEmpty()
                                            select new
                                            {
                                                Id = item?.Id,
                                                Name = item?.Name,
                                                Subject = s.Name,
                                            };
        }

        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int SubjectId { get; set; }

        }

        public class Subject
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class InnerJoinAndLeftOuterJoin
        {
            public void Main()
            {


               
            }

        }

    }




}