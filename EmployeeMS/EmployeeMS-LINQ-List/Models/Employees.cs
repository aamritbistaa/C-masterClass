namespace EmployeeMS_LINQ_List.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Positions Position { get; set; }
        public float Salary { get; set; }
        public int? DeptId { get; set; }
        public int? AddressId { get; set; }
        public List<string> Features = new List<string>();
    }
}