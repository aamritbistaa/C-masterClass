using System;

namespace Hangfire_Test.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public int CountryId { get; set; }
    public bool IsApproved { get; set; }
    public string Email { get; set; }

}
