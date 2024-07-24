using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using EmployeeMS_LINQ_List.Models;

namespace EmployeeMS_LINQ_List
{

    public class LinqClass
    {
        public static List<Departments> DepartmentList = new List<Departments> { };
        public static List<Address> AddressesList = new List<Address> { };
        public static List<Employees> EmployeeList = new List<Employees> { };

        public static List<Employees> EmployeeBackupList = new List<Employees> { };
        public static List<Attendance> AttendanceList = new List<Attendance> { };

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
            var getFeatures = EmployeeList
                .Select(item => item.Features);
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
                .OrderBy(x => x.Position)
            .GroupBy(x => new { x.Position, x.DeptId })
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

        public void EmployeesBySalaryGreaterThanHundredMillionFirstMethod()
        {
            var EmployeesBySalary = from item in EmployeeList
                                    orderby item.Salary descending
                                    where item.Salary > 100000000
                                    select item;
            var firstItem = EmployeesBySalary.First();
            System.Console.WriteLine($"First Name : {firstItem.Name} Nick Name : {firstItem.Nickname} Salary : {firstItem.Salary}");
        }

        public void EmployeesBySalaryGreaterThanHundredMillionFirstOrDefaultMethod()
        {
            var EmployeesBySalary = from item in EmployeeList
                                    orderby item.Salary descending
                                    where item.Salary > 100000000
                                    select item;
            var firstItem = EmployeesBySalary.FirstOrDefault();
            System.Console.WriteLine($"First Name : {firstItem?.Name} Nick Name : {firstItem?.Nickname} Salary : {firstItem?.Salary}");
        }

        public void EmployeesBySalaryGreaterThanThousandLast()
        {
            var EmployeesBySalary = from item in EmployeeList
                                    orderby item.Salary descending
                                    where item.Salary > 10000
                                    select item;
            var firstItem = EmployeesBySalary.Last();
            System.Console.WriteLine($"First Name : {firstItem?.Name} Nick Name : {firstItem?.Nickname} Salary : {firstItem?.Salary}");
        }
        public void EmployeesBySalaryGreaterThanThousandLastOrDefault()
        {
            var EmployeesBySalary = from item in EmployeeList
                                    orderby item.Salary descending
                                    where item.Salary > 10000
                                    select item;
            var firstItem = EmployeesBySalary.LastOrDefault();
            System.Console.WriteLine($"First Name : {firstItem?.Name} Nick Name : {firstItem?.Nickname} Salary : {firstItem?.Salary}");
        }
        public void EmployeeWithHighestSalaryElementAt(int index)
        {
            var EmployeesBySalary = from item in EmployeeList
                                    orderby item.Salary descending
                                    select item;
            var firstItem = EmployeesBySalary.ElementAt(index);
            System.Console.WriteLine($"First Name : {firstItem?.Name} Nick Name : {firstItem?.Nickname} Salary : {firstItem?.Salary}");
        }
        public void EmployeeWithHighestSalaryElementAtOrDefault(int index)
        {
            var EmployeesBySalary = from item in EmployeeList
                                    orderby item.Salary descending
                                    select item;
            var firstItem = EmployeesBySalary.ElementAtOrDefault(index);
            System.Console.WriteLine($"First Name : {firstItem?.Name} Nick Name : {firstItem?.Nickname} Salary : {firstItem?.Salary}");
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

        public void GroupJoin()
        {
            var groupedItem = from dept in DepartmentList
                              join people in EmployeeList
                              on dept.Id equals people.DeptId into groupedPeople
                              select new
                              {
                                  DepartmentName = dept.DeptName,
                                  Peoples = groupedPeople
                              };

            foreach (var item in groupedItem)
            {
                Console.WriteLine($"{item.DepartmentName}");
                foreach (var item1 in item.Peoples)
                {
                    Console.WriteLine($"{item1.Name}");
                }
            }
        }
        public void InnerSelfJoinOnEmployeeAndSupervisor()
        {
            var EmployeeWithSupervisor = from people in EmployeeList
                                         join people1 in EmployeeList
                                         on people.Id equals people1.SupervisorId
                                         select new
                                         {
                                             people.Name,
                                             people.Salary,
                                             people.Nickname,
                                             SupervisorName = people1.Name
                                         };

            foreach (var item in EmployeeWithSupervisor)
            {
                Console.WriteLine($"{item.Name} {item.Salary} {item.Nickname} {item.SupervisorName}");
            }
        }

        public void InnerJoinOfEmployees() //outerjoin
        {
            var AllEmployees = from people in EmployeeList
                               join people1 in EmployeeList
                               on people.SupervisorId equals people1.Id into supervisorDetail
                               from superv in supervisorDetail.DefaultIfEmpty()
                               select new
                               {
                                   Name = people.Name,
                                   SupervisorName = superv?.Name,
                               };

            foreach (var item in AllEmployees)
            {
                Console.WriteLine($"{item.Name} {item.SupervisorName}");
            }
        }

        public void ToLookup()
        {
            Console.WriteLine("Displaying all items\n");
            const int nameWidth = 15;
            const int positionWidth = 10;

            Console.WriteLine($"{"Name",-nameWidth} {"Position",-positionWidth}");
            foreach (var item in EmployeeList)
            {
                Console.WriteLine($"{item.Name,-nameWidth} {item.Position,-positionWidth}");
            }

            var OFTypeVariable = EmployeeList.ToLookup(x => x.Position);
            Console.WriteLine("\nDisplaying all according to Position \n");

            foreach (var item in OFTypeVariable)
            {
                Console.WriteLine(item.Key);

                foreach (var item1 in OFTypeVariable[item.Key])
                {
                    Console.WriteLine("\t {0}", item1.Name);
                }
                Console.WriteLine();
            }
        }

        public void MainFunction()
        {

            //! Seeding
            // EmployeeList
            Startup obj = new Startup();
            obj.SeedEmployee(ref EmployeeList);
            obj.SeedAddress(ref AddressesList);
            obj.SeedEmployeeBackup(ref EmployeeBackupList);
            obj.SeedAttendance(ref AttendanceList);
            obj.SeedDepartment(ref DepartmentList);


            //! Projection
            //* Select
            //GetAllEmployee();
            //* SelectMany
            //GetAllFeatures();

            //! Filtering
            //* Where
            // GetAllJuniors();
            //* OfType
            //GetAllEmployeeDateOfBirth();
            //var Salaries = ReturnAllSalary();
            //* ToLookUp
            ToLookup();


            //! Order
            //* OrderBy ThenBy 
            //GetAllEmployeeAccordingToPosition();
            //* OrderByDescending ThenByDescending
            // GetAllEmployeeAccordingToPositionDesc();

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

            /*
            //*All tables
            Console.WriteLine("Employee list");
            DisplayAllEmployees(EmployeeList);
            Console.WriteLine();
            Console.WriteLine("Employee backup list");
            DisplayAllEmployees(EmployeeBackupList);
            Console.WriteLine();
            */

            /*
            //* UNION
            Console.WriteLine("Displaying Union of two list");
            var result = EmployeeList.Union(EmployeeBackupList);

            foreach (var item in result)
            {
                if (item.Features.Any())
                {
                    string features = "";
                    foreach (var item1 in item.Features)
                    {
                        features = features + ", " + item1;
                    }
                    Console.WriteLine($"ID : {item.Id} Name : {item.Name} DateOfBirth : {item.DateOfBirth} Position : {item.Position} Address : {item.AddressId} Department : {item.DeptId} Salary : {item.Salary}");
                    continue;
                }
                Console.WriteLine($"ID : {item.Id} Name : {item.Name} DateOfBirth : {item.DateOfBirth} Position : {item.Position} Address : {item.AddressId} Department : {item.DeptId} Salary : {item.Salary}");
            }
            Console.WriteLine();
            */

            /*
            //* INTERSECTION
            Console.WriteLine("Intersection result");

            var intersetionResult = EmployeeList.Intersect(EmployeeBackupList);

            foreach (var item in intersetionResult)
            {
                if (item.Features.Any())
                {
                    string features = "";
                    foreach (var item1 in item.Features)
                    {
                        features = features + ", " + item1;
                    }
                    Console.WriteLine($"ID : {item.Id} Name : {item.Name} DateOfBirth : {item.DateOfBirth} Position : {item.Position} Address : {item.AddressId} Department : {item.DeptId} Salary : {item.Salary} Feature : {features}");
                    continue;
                }
                Console.WriteLine($"ID : {item.Id} Name : {item.Name} DateOfBirth : {item.DateOfBirth} Position : {item.Position} Address : {item.AddressId} Department : {item.DeptId} Salary : {item.Salary}");
            }
            Console.WriteLine();
            */

            //* UnionBy
            //ListOfEmployeeName(); //* union on the basis of name
            //ListOfPeopleHavingUniqueNameAndPosition(); //* union on the basis of name and position
            /*
            var unionByName = EmployeeList.UnionBy(EmployeeBackupList, item => new
            {
                item.Name
            });
            foreach (var item in unionByName)
            {
                if (item.Features.Any())
                {
                    string features = "";
                    foreach (var item1 in item.Features)
                    {
                        features = features + ", " + item1;
                    }
                    Console.WriteLine($"ID : {item.Id} Name : {item.Name} DateOfBirth : {item.DateOfBirth} Position : {item.Position} Address : {item.AddressId} Department : {item.DeptId} Salary : {item.Salary} Feature : {features}");
                    continue;
                }
                Console.WriteLine($"ID : {item.Id} Name : {item.Name} DateOfBirth : {item.DateOfBirth} Position : {item.Position} Address : {item.AddressId} Department : {item.DeptId} Salary : {item.Salary}");
            }
            */

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
            // Throws error if item is not found
            // EmployeesBySalaryGreaterThanHundredMillionFirstMethod();
            //* FirstOrDefault
            // EmployeesBySalaryGreaterThanHundredMillionFirstOrDefaultMethod();
            //* Last
            // EmployeesBySalaryGreaterThanThousandLast();
            //* LastOrDefault
            // EmployeesBySalaryGreaterThanThousandLastOrDefault();
            //* Single

            //* ElementAt
            // EmployeeWithHighestSalaryElementAt(3);
            //* ElementAtOrDefault
            // EmployeeWithHighestSalaryElementAtOrDefault(20);

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
            //* Join with nullable address and department
            var items = from people in EmployeeList
                        join add in AddressesList
                        on people.AddressId equals add.Id into address
                        join dept in DepartmentList
                        on people.DeptId equals dept.Id into departments
                        from addressitem in address.DefaultIfEmpty()
                        from deptitem in departments.DefaultIfEmpty()
                        select new
                        {
                            people.Id,
                            people.Name,
                            people.Salary,
                            people.DateOfBirth,
                            addressitem?.City,
                            people.Position,
                            deptitem?.DeptName,
                        };
            //! GroupJoin
            //GroupJoin();
            //* InnerJoin
            //* Inner Self Join
            //InnerSelfJoinOnEmployeeAndSupervisor();
            //InnerJoinOfEmployees();


            //* OuterJoin
            //* LeftOuterJoin



            //* CrossJoin

            var allEmployee = from people in EmployeeList
                              join people1 in EmployeeList
                              on people.SupervisorId equals people1.Id into peopleDetails
                              from peop in peopleDetails.DefaultIfEmpty()
                              select new
                              {
                                  people.Name,
                                  people.Salary,
                                  people.Nickname,
                                  SupervisorName = peop?.Name
                              };

            //* To get all the details

            var allDetails = from people in EmployeeList
                             join address in AddressesList
                             on people.AddressId equals address.Id into addresses
                             join department in DepartmentList
                             on people.DeptId equals department.Id into departments
                             join people1 in EmployeeList
                             on people.Id equals people1.SupervisorId into supervisors
                             from add in addresses.DefaultIfEmpty()
                             from dept in departments.DefaultIfEmpty()
                             from super in supervisors.DefaultIfEmpty()
                             select new
                             {
                                 EmployeeName = people.Name,
                                 EmployeeDepartment = dept?.DeptName,
                                 EmployeeAddress = add?.City,
                                 SupervisorName = super?.Name
                             };

            // foreach (var item in allDetails)
            // {
            //     System.Console.WriteLine($"Name : {item.EmployeeName} Department : {item.EmployeeDepartment}  Address : {item.EmployeeAddress} Reporting to : {item.SupervisorName}");
            // }




            //* IntersectBy

            System.Console.ReadLine();
        }
    }
}