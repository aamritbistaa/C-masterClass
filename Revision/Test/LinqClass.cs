using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Test;

public enum Positions
{
    Lead,
    Senior,
    Junior,
    Intern
}
public static class Helpers
{
    public static DateOnly GetTodayDate()
    {
        DateTime today = DateTime.Today;
        var todayDate = today.ToShortDateString();
        return DateOnly.Parse(todayDate);
    }
}
public class Attendance
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int EmpId { get; set; }
    public DateTime InTime { get; set; }
    public DateTime OutTime { get; set; }
    public DateOnly TodayDate { get; } = Helpers.GetTodayDate();
}

public class Employees
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Nickname { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public Positions Position { get; set; }
    public float Salary { get; set; }
    public int DeptId { get; set; }
    public int AddressId { get; set; }
    public List<string> Features = new List<string>();
}
public class Address
{
    public int Id { get; set; }
    public string City { get; set; }
}
public class Departments
{
    public int Id { get; set; }
    public string DeptName { get; set; }
}

public class LinqClass
{
    public static List<Departments> DepartmentList = new List<Departments>{
            new Departments{
                Id=0,
                DeptName="Frontend"
            },new Departments{
                Id=1,
                DeptName="Backend"
            },new Departments{
                Id=2,
                DeptName="Flutter"
            }
        };
    public static List<Address> AddressesList = new List<Address>{
            new Address{
                Id=0,
                City="Baneshwor"
            }
            ,new Address{
                Id=1,
                City="Baluwatar"
            },
            new Address{
                Id=2,
                City="Sinamangal"
            }
        };
    public static List<Employees> EmployeeList = new List<Employees>{
            new Employees{
                Id=0,
                Name="Sheru",
                DateOfBirth = new DateOnly(2000,1, 1),
                Nickname="SuperMan",
                Position = Positions.Junior,
                Salary =10000,
                DeptId = 0,
                AddressId =2,
                Features = new List<string>{"feature1","feature2"}
            },
            new Employees{
                Id=1,
                Name="SherBahadur",
                DateOfBirth = new DateOnly(2002,2, 21),
                Nickname="Batman",
                Position = Positions.Senior,
                Salary =1500000,
                DeptId = 1,
                AddressId =2,
                Features = new List<string>{"feature3","feature4"}
            },
            new Employees{
                Id=2,
                Name="Hari Bahadur",
                Nickname="Haribahadur",
                DateOfBirth = new DateOnly(2000,1, 1),
                Position = Positions.Intern,
                Salary =10000,
                DeptId = 0,
                AddressId =2,
                Features = new List<string>{"feature5","feature6", "feature2" }
            },
            new Employees{
                Id=3,
                Name="Bahadur",
                DateOfBirth = new DateOnly(2000,1, 1),
                Position = Positions.Lead,
                Salary =910000,
                DeptId = 2,
                AddressId =2
            },
            new Employees{
                Id=4,
                Name="Heera Lal",
                DateOfBirth = new DateOnly(2000,1, 1),
                Position = Positions.Junior,
                Salary =10000,
                DeptId = 0,
                AddressId =2
            }, new Employees{
                Id=9,
                Name="Heera Lal6",
                DateOfBirth = new DateOnly(2000,1, 1),
                Position = Positions.Junior,
                Salary =10000,
                DeptId = 0,
                AddressId =2
            }, new Employees{
                Id=9,
                Name="Heera Lal6",
                DateOfBirth = new DateOnly(2000,1, 1),
                Position = Positions.Junior,
                Salary =10000,
                DeptId = 0,
                AddressId =2
            },
        };

    public static List<Employees> EmployeeBackupList = new List<Employees>{
            new Employees{
                Id=0,
                Name="Sheru",
                DateOfBirth = new DateOnly(2000,1, 1),
                Nickname="SuperMan",
                Position = Positions.Junior,
                Salary =10000,
                DeptId = 0,
                AddressId =2,
                Features = new List<string>{"feature1","feature2"}
            },
            new Employees{
                Id=1,
                Name="SherBahadur",
                DateOfBirth = new DateOnly(2002,2, 21),
                Nickname="Batman",
                Position = Positions.Senior,
                Salary =1500000,
                DeptId = 1,
                AddressId =2,
                Features = new List<string>{"feature3","feature4"}
            },
            new Employees{
                Id=2,
                Name="Hari Bahadur",
                Nickname="Haribahadur",
                DateOfBirth = new DateOnly(1995,1, 1),
                Position = Positions.Intern,
                Salary =10000,
                DeptId = 0,
                AddressId =2,
                Features = new List<string>{"feature5","feature6"}
            },
            new Employees{
                Id=3,
                Name="Bahadur",
                DateOfBirth = new DateOnly(2009,1, 1),
                Position = Positions.Lead,
                Salary =910000,
                DeptId = 2,
                AddressId =2
            },


        };
    public static List<Attendance> AttendanceList = new List<Attendance>{
            new Attendance{
                EmpId=0,
                InTime= new DateTime(2024, 12, 25, 9, 00, 30),
                OutTime= new DateTime(2024, 12, 25, 17, 50, 30)
            },
            new Attendance{
                EmpId=0,
                InTime= new DateTime(2024, 12, 26, 9, 00, 30),
                OutTime= new DateTime(2024, 12, 26, 17, 50, 30)
            },
            new Attendance{
                EmpId=0,
                InTime= new DateTime(2024, 12, 26, 9, 00, 30),
                OutTime= new DateTime(2024, 12, 26, 17, 50, 30)
            },
            new Attendance{
                EmpId=0,
                InTime= new DateTime(2024, 12, 27, 9, 00, 30),
                OutTime= new DateTime(2024, 12, 27, 17, 50, 30)
            },
            new Attendance{
                EmpId=0,
                InTime= new DateTime(2024, 12, 28, 9, 00, 30),
                OutTime= new DateTime(2024, 12, 28, 17, 50, 30)
            }
        };
    public void GetAllEmployee()
    {
        var GetAllEmployee = from item in EmployeeList
                             select item;

        foreach (var emp in GetAllEmployee)
        {
            Console.WriteLine($"{emp.Id} : {emp.Name} {emp.DateOfBirth}" +
                $" {emp.Position} {emp.Salary}");
        }

    }
    public void GetAllJuniors()
    {
        var GetAllJuniors = from item in EmployeeList
                            where item.Position == Positions.Junior
                            select item;
        foreach (var emp in GetAllJuniors)
        {
            Console.WriteLine($"{emp.Id} : {emp.Name} " +
                $"{emp.DateOfBirth} {emp.Position} {emp.Salary}");
        }
    }
    public void GetAllFeatures()
    {
        var GetAllFeatures = EmployeeList
            .SelectMany(item => item.Features);
        foreach (var feature in GetAllFeatures)
        {
            System.Console.WriteLine(feature);
        }
    }
    public void GetAllEmployeeDateOfBirth()
    {
        List<object> items = new List<object>();
        foreach (var item in EmployeeList)
        {
            items.Add(item.Id);
            items.Add(item.Name);
            items.Add(item.Nickname);
            items.Add(item.Position);
            items.Add(item.DateOfBirth);
            items.Add(item.Salary);
        }
        var DOBs = from item in items.OfType<DateOnly>()
                   select item;
        foreach (var item in DOBs)
        {
            System.Console.WriteLine(item);
        }
    }

    public List<float> ReturnAllSalary()
    {
        List<object> items = new List<object> { };
        foreach (var item in EmployeeList)
        {
            items.Add(item.Id);
            items.Add(item.Name);
            items.Add(item.Nickname);
            items.Add(item.Position);
            items.Add(item.DateOfBirth);
            items.Add(item.Salary);
        }
        var salaries = (from item in items.OfType<float>()
                        select item).ToList();
        foreach (var item in salaries)
        {
            System.Console.WriteLine(item);
        }

        return salaries;

    }

    public void GetAllEmployeeAccordingToPosition()
    {
        var GetAllEmployeeAccordingToPosition = EmployeeList.OrderBy(item => item.Position)
                                                            .ThenBy(item => item.Salary);
        foreach (var emp in GetAllEmployeeAccordingToPosition)
        {
            System.Console.WriteLine($"{emp.Id} : {emp.Name} {emp.DateOfBirth} {emp.Position} {emp.Salary}");
        }
    }
    public void GetAllEmployeeAccordingToPositionDesc()

    {


        var GetAllEmployeeAccordingToPosition = EmployeeList.OrderByDescending(item => item.Position)
                                                                                            .ThenBy(item => item.Name)
                                                                                            .ThenByDescending(item => item.Salary);
        var EmployeeAccordingToPositonDescending = from item in EmployeeList
                                                   orderby item.Position descending,
                                                           item.Name descending,
                                                           item.Salary descending
                                                   select item;
        var ReversedEmployeeAccordingToPositionDescending = EmployeeAccordingToPositonDescending.Reverse();

        foreach (var emp in EmployeeAccordingToPositonDescending)
        {
            System.Console.WriteLine($"{emp.Id} : {emp.Name} {emp.DateOfBirth} {emp.Position} {emp.Salary}");
        }

        Console.WriteLine("\n");
        foreach (var emp in ReversedEmployeeAccordingToPositionDescending)
        {
            System.Console.WriteLine($"{emp.Id} : {emp.Name} {emp.DateOfBirth} {emp.Position} {emp.Salary}");
        }
    }
    public void GetAllElementByPosition()
    {
        var GetAllEmployeeByPosition = from item in EmployeeList
                                       group item by item.Position into itemContent
                                       orderby itemContent.Key ascending
                                       select new
                                       {
                                           Positions = itemContent.Key,
                                           Details = (from item in itemContent
                                                      select new
                                                      {
                                                          item.Id,
                                                          item.Name,
                                                          item.Salary,
                                                          item.DateOfBirth
                                                      }
                                           )
                                       };

        foreach (var item in GetAllEmployeeByPosition)
        {
            System.Console.WriteLine(item.Positions);
            foreach (var emp in item.Details)
            {
                System.Console.WriteLine($"{emp.Id} : {emp.Name} {emp.DateOfBirth} {emp.Salary}");
            }
        }
    }

    public void GetAllElementByPositionAndDepartment()
    {
        var GetAllElementByPositionAndDepartment =
            EmployeeList
        .GroupBy(x => new { x.Position, x.DeptId })
        .OrderBy(x => x.Key.Position)
        .Select(x => new
        {
            Key = x.Key,
            Details = x.Select(x => new
            {
                x.Id,
                x.Name,
                x.Salary,
                x.DateOfBirth,
            })
        });
        foreach (var item in GetAllElementByPositionAndDepartment)
        {
            System.Console.WriteLine($"Position: {item.Key.Position}");
            System.Console.WriteLine($"Department: {item.Key.DeptId}");
            foreach (var emp in item.Details)
            {
                System.Console.WriteLine($"{emp.Id} : {emp.Name} {emp.DateOfBirth} {emp.Salary}");
            }
        }
    }

    public void UnionOnTheBasisOfNamePositionSalary()
    {
        var AllEmployee = (EmployeeList.Select(x => new
        {
            x.Name,
            x.Position,
            x.Salary
        })).Union(EmployeeBackupList.Select(x => new
        {
            x.Name,
            x.Position,
            x.Salary
        }));
        foreach (var item in AllEmployee)
        {
            System.Console.WriteLine($"{item.Name} {item.Salary} {item.Position}");
        }
    }
    public void IntersectionOnTheBasisOfNamePositionSalary()
    {
        var commonEmployee = (EmployeeList.Select(x => new
        {
            x.Name,
            x.Position,
            x.Salary
        })).Intersect(EmployeeBackupList.Select(x => new
        {
            x.Name,
            x.Position,
            x.Salary
        }));
        foreach (var item in commonEmployee)
        {
            System.Console.WriteLine($"{item.Name} {item.Salary} {item.Position}");
        }
    }
    public void ListOfEmployeeName()
    {
        var empList = EmployeeList.Select(x => new
        {
            x.Name,
            x.Position,
            x.Salary,
        });

        var empBackupList = EmployeeBackupList.Select(x => new
        {
            x.Name,
            x.Position,
            x.Salary
        });
        var allName = (empList).UnionBy(empBackupList, x => x.Name);
        foreach (var item in allName)
        {
            Console.WriteLine($"{item.Name} {item.Salary} {item.Position}");
        }
    }
    public void ListOfPeopleHavingUniqueNameAndPosition()
    {
        var empList = EmployeeList.Select(x => new
        {
            x.Name,
            x.Position,
            x.Salary,
        });

        var empBackupList = EmployeeBackupList.Select(x => new
        {
            x.Name,
            x.Position,
            x.Salary
        });
        var allUniqueNameAndDOB = (empList).UnionBy(empBackupList, x => new { x.Name, x.Position });
        foreach (var item in allUniqueNameAndDOB)
        {
            Console.WriteLine($"{item.Name} {item.Salary} {item.Position}");
        }
    }
    public void ListOfEmployeeHavingCommonNameAndDOB()
    {
        var empList = EmployeeList.Select(x => new
        {
            x.Name,
            x.DateOfBirth,
        });

        var empBackupList = EmployeeBackupList.Select(x => new
        {
            x.Name,
            x.DateOfBirth,
        });
        var allName = (empList).Intersect(empBackupList);
        foreach (var item in allName)
        {
            Console.WriteLine($"{item.Name} {item.DateOfBirth}");
        }
    }
    public void EmployeeWithDistinctIdNameNicknameDOB()
    {

        Console.WriteLine("Displaying all items of the list ");
        foreach (var item in EmployeeList)
        {
            Console.WriteLine($"{item.Id}, {item.Name},{item.Position},{item.Salary}");
        }
        Console.WriteLine("Displaying unique items on the basis of Id, Nickname, Name, DOB only ");
        var uniqueEmployeeList = EmployeeList.DistinctBy(x => new
        {
            x.Nickname,
            x.Id,
            x.Name,
            x.DateOfBirth,
        });
        foreach (var item in uniqueEmployeeList)
        {
            Console.WriteLine($"ID : {item.Id} Name : {item.Name} DateOfBirth : {item.DateOfBirth} " +
                $"Position : {item.Position} Address : {item.AddressId} Department : {item.DeptId} Salary : {item.Salary}");
        }
    }

    public void ListOfAllEmployeeList()
    {
        var empList1 = from item in EmployeeList
                       select item;
        var empList2 = from item in EmployeeBackupList
                       select item;

        var allEmployee = empList1.Concat(empList2);
        foreach (var item in allEmployee)
        {
            Console.WriteLine($"ID: {item.Id} Name :{item.Name} " +
                $"Position : {item.Position} Salary : {item.Salary}");
        }
    }

    public void ListOfEmployeeExceptIntern()
    {
        var listOfAllIntern = EmployeeList.Select(x => x).Where(x => x.Position == Positions.Intern);
        var listOfAllNonIntern = EmployeeList.Except(listOfAllIntern);

        foreach (var item in listOfAllNonIntern)
        {
            Console.WriteLine($"ID : {item.Id} Name : {item.Name} DateOfBirth : {item.DateOfBirth} " +
                $"Position : {item.Position} Address : {item.AddressId} Department : {item.DeptId} Salary : {item.Salary}");
        }
    }

    public void IsSalaryMorethan10000()
    {
        var result = EmployeeList.All(x => x.Salary >= 10000);
        Console.WriteLine("Is salary more than 10000? {0}", result);
    }
    public void HasEmployeeBackupListBornAfter2008()
    {
        var Emp = (from item in EmployeeBackupList
                   where item.DateOfBirth >= new DateOnly(2008, 1, 1)
                   select item);
        var result = Emp.Any();

        Console.WriteLine("Has Employee Born After 2008 ? {0}", result);
    }
    public void HasEmployeeListBornAfter2005()
    {
        var result = EmployeeList.Any(item => item.DateOfBirth >= new DateOnly(2005, 1, 1));
        Console.WriteLine("Has Employee Born After 2005 ? {0}", result);

    }

    public void IsItemFromEmployeeListContainedInEmployeeBackUpList()
    {
        var emp = (from item in EmployeeList
                   where item.Id == 9
                   select item).ToList();
        if (emp.Any())
        {
            var result = EmployeeBackupList.Contains(emp[0]);
            Console.WriteLine($"Employee id 9 from EmployeeList is contained in EmployeeBackupList: {result}");
            return;
        }
        Console.WriteLine($"Employee id 9 from EmployeeList is not contained in EmployeeBackupList");



    }



    public void DisplayAllEmployees(List<Employees> listParam)
    {
        foreach (var item in listParam)
        {

            if (!item.Features.Any())
            {
                Console.WriteLine($"ID : {item.Id} Name : {item.Name} DateOfBirth : {item.DateOfBirth} Position : {item.Position} Address : {item.AddressId} Department : {item.DeptId} Salary : {item.Salary}");
                continue;
            }
            string features = "";
            foreach (var item1 in item.Features)
            {
                features = features + item1 + ", ";
            }
            Console.WriteLine($"ID : {item.Id} Name : {item.Name} DateOfBirth : {item.DateOfBirth} Position : {item.Position} Address : {item.AddressId} Department : {item.DeptId} Salary : {item.Salary} Features : {features}");
        }
    }


    public void MainFunction()
    {
        //! Projection
        //* Select
        //GetAllEmployee();
        //* SelectMany
        //GetAllFeatures();

        //! Filtering
        //* Where
        //GetAllJuniors();
        //* OfType
        //GetAllEmployeeDateOfBirth();
        //var Salaries = ReturnAllSalary();

        //! Order
        //* OrderBy ThenBy 
        //GetAllEmployeeAccordingToPosition();
        //* OrderByDescending ThenByDescending
        GetAllEmployeeAccordingToPositionDesc();

        //! Grouping
        //* Single key
        //GetAllElementByPosition();
        //* Multiple key
        //GetAllElementByPositionAndDepartment();
        //* LookUp


        //! Aggregate Methods
        /*
         //* Sum
         var sumOfSalaries = Salaries.Sum();
         System.Console.WriteLine("Total Salary of All Employees {0}", sumOfSalaries);
         //* Average
         var averageOfSalaries = Salaries.Average();
         System.Console.WriteLine("Total Average Salary of All Employees {0}", averageOfSalaries);
         //* Count
         var totalPaidEmployees = Salaries.Count();
         System.Console.WriteLine("Total Paid Employee {0}", totalPaidEmployees);
         //* Min
         var minOfSalary = Salaries.Min();
         System.Console.WriteLine("Minimum Salary of {0}", minOfSalary);
         //* Max
         var maxOfSalary = Salaries.Sum();
         System.Console.WriteLine("Maximum Salary {0}", maxOfSalary);

         //* Aggregate
         var allNickName = EmployeeList.Select(x => x.Nickname).Aggregate((a, b) => a + ", " + b);
         System.Console.WriteLine("List of all nickname: {0}", allNickName);
        */




        //! Set Operation
        //Console.WriteLine("Employee Backup List");
        //DisplayAllEmployees(EmployeeBackupList);
        //Console.WriteLine("Employee List");
        //DisplayAllEmployees(EmployeeList);
        //* Union
        // Union based on Name, Position and Salary
        //UnionOnTheBasisOfNamePositionSalary();
        //* UnionBy
        //ListOfEmployeeName(); //* union on the basis of name
        //ListOfPeopleHavingUniqueNameAndPosition(); //* union on the basis of name and position

        //EmployeeBackupList
        //* Intersection
        //IntersectionOnTheBasisOfNamePositionSalary();
        //ListOfEmployeeHavingCommonNameAndDOB();

        //* Concat
        //ListOfAllEmployeeList();

        //* Distinct
        //EmployeeWithDistinctIdNameNicknameDOB();

        //* Except
        //ListOfEmployeeExceptIntern();

        //! Quantifier
        //* All
        //IsSalaryMorethan10000();
        //* Any
        //DisplayAllEmployees(EmployeeList);

        //HasEmployeeBackupListBornAfter2008();
        //HasEmployeeListBornAfter2005();
        //* Contains
        //IsItemFromEmployeeListContainedInEmployeeBackUpList();

        //! Element Operations
        //* First
        //* FirstOrDefault
        //* Last
        //* LastOrDefault
        //* Single
        //* ElementAt
        //* ElementAtOrDefault

        //! Partitioning Operators
        //* Take
        //* Skip
        //* TakeWhile
        //* SkipWhile


        //* Zip

        //List<int> listOfInformation = new List<int> { 1, 2, 3, 4, 5, 6, 7};
        //List<string> listOfStringInformation = new List<string> { "First", "Second", "Third", "Fourth", "Fifth" };
        //var newInfo = listOfInformation.Zip(listOfStringInformation);
        //foreach (var item in newInfo)
        //{
        //    Console.WriteLine($"{item.First} :: {item.Second}");
        //}

        //List<float> listOfFloatInformation = new List<float> { 1.0f, 11.20f, 192312.92f, 19212.23f, 123123.29f };
        //var newInformation = listOfInformation.Zip(listOfStringInformation).Zip(listOfFloatInformation);
        //foreach(var item in newInformation)
        //{
        //    Console.WriteLine($"{item.First.First} :: {item.First.Second} :: {item.Second}");
        //}

        //* Append
        //* Prepend

        //*ToList
        //*ToDictionary
        //*ToArray

        //! Join
        //* InnerJoin
        //* OuterJoin
        //* LeftOuterJoin


        //* IntersectBy

        System.Console.ReadLine();
    }
}