using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMS_LINQ_List.Models;

namespace EmployeeMS_LINQ_List
{
    public class Startup
    {
        public void SeedAttendance(ref List<Attendance> attendanceList)
        {
            attendanceList.Add(
            new Attendance
            {
                EmpId = 0,
                InTime = new DateTime(2024, 12, 25, 9, 00, 30),
                OutTime = new DateTime(2024, 12, 25, 17, 50, 30)
            });
            attendanceList.Add(
            new Attendance
            {
                EmpId = 0,
                InTime = new DateTime(2024, 12, 26, 9, 00, 30),
                OutTime = new DateTime(2024, 12, 26, 17, 50, 30)
            });
            attendanceList.Add(
            new Attendance
            {
                EmpId = 0,
                InTime = new DateTime(2024, 12, 26, 9, 00, 30),
                OutTime = new DateTime(2024, 12, 26, 17, 50, 30)
            });
            attendanceList.Add(
            new Attendance
            {
                EmpId = 0,
                InTime = new DateTime(2024, 12, 27, 9, 00, 30),
                OutTime = new DateTime(2024, 12, 27, 17, 50, 30)
            });
            attendanceList.Add(new Attendance
            {
                EmpId = 0,
                InTime = new DateTime(2024, 12, 28, 9, 00, 30),
                OutTime = new DateTime(2024, 12, 28, 17, 50, 30)
            });
        }
        public void SeedEmployeeBackup(ref List<Employees> employeeBackupList)
        {
            employeeBackupList.Add(new Employees
            {
                Id = 0,
                Name = "Sheru",
                DateOfBirth = new DateOnly(2000, 1, 1),
                Nickname = "SuperMan",
                Position = Positions.Junior,
                Salary = 10000,
                DeptId = 0,
                AddressId = 0,
                Features = new List<string> { "feature1", "feature2" }
            });
            employeeBackupList.Add(
            new Employees
            {
                Id = 1,
                Name = "SherBahadur",
                DateOfBirth = new DateOnly(2002, 2, 21),
                Nickname = "Batman",
                Position = Positions.Senior,
                Salary = 1500000,
                DeptId = 1,
                AddressId = 1,
                Features = new List<string> { "feature3", "feature4" }
            });
            employeeBackupList.Add(
            new Employees
            {
                Id = 2,
                Name = "Hari Bahadur",
                Nickname = "Haribahadur",
                DateOfBirth = new DateOnly(1995, 1, 1),
                Position = Positions.Intern,
                Salary = 10000,
                DeptId = 0,
                AddressId = 2,
                Features = new List<string> { "feature5", "feature6" }
            });
            employeeBackupList.Add(
            new Employees
            {
                Id = 3,
                Name = "Bahadur",
                DateOfBirth = new DateOnly(2009, 1, 1),
                Position = Positions.Lead,
                Salary = 910000,
                DeptId = 2,
                AddressId = 3
            });
            employeeBackupList.Add(
            new Employees
            {
                Id = 4,
                Name = "Heera Lal",
                DateOfBirth = new DateOnly(2010, 1, 1),
                Position = Positions.Junior,
                Salary = 10000,
                DeptId = 0,
                AddressId = 4
            });
            employeeBackupList.Add(new Employees
            {
                Id = 5,
                Name = "Heera Lal2",
                DateOfBirth = new DateOnly(2000, 1, 1),
                Position = Positions.Senior,
                Salary = 10000,
                DeptId = 0,
                AddressId = 5
            });
            employeeBackupList.Add(new Employees
            {
                Id = 6,
                Name = "Heera Lal3",
                DateOfBirth = new DateOnly(2005, 1, 1),
                Position = Positions.Senior,
                Salary = 15000,
                DeptId = 0,
                AddressId = 6
            });
            employeeBackupList.Add(new Employees
            {
                Id = 7,
                Name = "Heera Lal4",
                DateOfBirth = new DateOnly(2002, 1, 1),
                Position = Positions.Intern,
                Salary = 10000,
                DeptId = 0,
                AddressId = 7
            });
            employeeBackupList.Add(new Employees
            {
                Id = 8,
                Name = "Heera Lal5",
                DateOfBirth = new DateOnly(1998, 1, 1),
                Position = Positions.Senior,
                Salary = 10000,
                DeptId = 0,
                AddressId = 8
            });
            employeeBackupList.Add(new Employees
            {
                Id = 9,
                Name = "Heera Lal6",
                DateOfBirth = new DateOnly(1995, 1, 21),
                Position = Positions.Junior,
                Salary = 9999910000,
                DeptId = 0,
                AddressId = 9
            });

        }
        public void SeedDepartment(ref List<Departments> departmentList)
        {
            departmentList.Add(new Departments
            {
                Id = 0,
                DeptName = "Frontend"
            });
            departmentList.Add(new Departments
            {
                Id = 1,
                DeptName = "Backend"
            });
            departmentList.Add(new Departments
            {
                Id = 2,
                DeptName = "Flutter"
            });
        }
        public void SeedAddress(ref List<Address> addressList)
        {
            addressList.Add(new Address
            {
                Id = 0,
                City = "Baneshwor"
            });
            addressList.Add(new Address
            {
                Id = 1,
                City = "Baluwatar"
            });
            addressList.Add(new Address
            {
                Id = 2,
                City = "Sinamangal"
            });

            addressList.Add(new Address
            {
                Id = 3,
                City = "Shantinagar"
            });

            addressList.Add(new Address
            {
                Id = 4,
                City = "Kalimati"
            });

            addressList.Add(new Address
            {
                Id = 5,
                City = "Lazimpat"
            });


            addressList.Add(new Address
            {
                Id = 6,
                City = "Babbarmahal"
            });

            addressList.Add(new Address
            {
                Id = 7,
                City = "Jadibuti"
            });

            addressList.Add(new Address
            {
                Id = 8,
                City = "Jawlakhel"
            });

            addressList.Add(new Address
            {
                Id = 9,
                City = "Dhapakhel"
            });
        }
        public void SeedEmployee(ref List<Employees> employeeList)
        {
            employeeList.Add(new Employees
            {
                Id = 0,
                Name = "Sheru",
                DateOfBirth = new DateOnly(2000, 1, 1),
                Nickname = "SuperMan",
                Position = Positions.Junior,
                Salary = 10000,
                DeptId = 0,
                AddressId = 2,
                Features = new List<string> { "feature1", "feature2" }
            });
            employeeList.Add(new Employees
            {
                Id = 1,
                Name = "SherBahadur",
                DateOfBirth = new DateOnly(2002, 2, 21),
                Nickname = "Batman",
                Position = Positions.Senior,
                Salary = 1500000,
                DeptId = 1,
                AddressId = 2,
                Features = new List<string> { "feature3", "feature4" }
            });
            employeeList.Add(new Employees
            {
                Id = 2,
                Name = "Hari Bahadur",
                Nickname = "Haribahadur",
                DateOfBirth = new DateOnly(2000, 1, 1),
                Position = Positions.Intern,
                Salary = 10000,
                DeptId = 0,
                AddressId = 2,
                Features = new List<string> { "feature5", "feature6", "feature2" },
                SupervisorId = 10
            });
            employeeList.Add(new Employees
            {
                Id = 3,
                Name = "Bahadur",
                DateOfBirth = new DateOnly(2000, 1, 1),
                Position = Positions.Lead,
                Salary = 910000,
                DeptId = 2,
                AddressId = 2
            });
            employeeList.Add(new Employees
            {
                Id = 4,
                Name = "Heera Lal",
                DateOfBirth = new DateOnly(2000, 1, 1),
                Position = Positions.Junior,
                Salary = 10000,
                DeptId = 0,
                AddressId = 2
            });
            employeeList.Add(new Employees
            {
                Id = 5,
                Name = "Heera Lal2",
                DateOfBirth = new DateOnly(2000, 1, 1),
                Position = Positions.Senior,
                Salary = 10000,
                DeptId = 0,
                AddressId = 2
            });
            employeeList.Add(new Employees
            {
                Id = 6,
                Name = "Heera Lal3",
                DateOfBirth = new DateOnly(2000, 1, 1),
                Position = Positions.Senior,
                Salary = 15000,
                DeptId = 0,
                AddressId = 2
            });
            employeeList.Add(new Employees
            {
                Id = 7,
                Name = "Heera Lal4",
                DateOfBirth = new DateOnly(2000, 1, 1),
                Position = Positions.Lead,
                Salary = 10000,
                DeptId = 0,
                AddressId = 2
            });
            employeeList.Add(new Employees
            {
                Id = 8,
                Name = "Heera Lal5",
                DateOfBirth = new DateOnly(2000, 1, 1),
                Position = Positions.Senior,
                Salary = 10000,
                DeptId = 0,
                AddressId = 2
            });
            employeeList.Add(new Employees
            {
                Id = 9,
                Name = "Heera Lal6",
                DateOfBirth = new DateOnly(2000, 1, 1),
                Position = Positions.Junior,
                Salary = 10000,
                DeptId = 0,
                AddressId = 2
            });
            employeeList.Add(new Employees
            {
                Id = 9,
                Name = "Heera Lal6",
                DateOfBirth = new DateOnly(2000, 1, 1),
                Position = Positions.Junior,
                Salary = 10000,
                DeptId = 0,
                AddressId = 2
            });
            employeeList.Add(new Employees
            {
                Id = 10,
                Name = "Lallu Lal",
                DateOfBirth = new DateOnly(2000, 1, 1),
                Position = Positions.Junior,
                Salary = 10000,
            });
            employeeList.Add(new Employees
            {
                Id = 11,
                Name = "Lallu Lal",
                DateOfBirth = new DateOnly(2000, 1, 1),
                Position = Positions.Junior,
                Salary = 10000,
            });

        }
    }
}