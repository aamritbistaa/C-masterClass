using EmployeeMS.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMS.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //var usr = new User
            //{
            //    Name = "Admin",
            //    DateOfBirth = "  ",
            //    Email = "admin@admin.com",
            //    PhoneNumber = " ",
            //    UniqueId = " ",
            //    Gender = " ",
            //    Password = " ",
            //    salt = " "
            //};
            //var emp = new Employee
            //{
            //    Position = "admin",
            //    Salary = 0,
            //    UserId = usr.Id,
            //};
            //modelBuilder.Entity<User>().HasData(usr);
            //modelBuilder.Entity<Employee>().HasData(emp);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Attendance> Attendances { get; set; }


        public void SaveDatabase()
        {
            base.SaveChanges();
        }
    }
}
