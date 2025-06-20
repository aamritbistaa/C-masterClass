using System;

namespace Hangfire_Test.Properties;

public class AddStudentRequestDto
{
    public string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public int CountryId { get; set; }
    public string Email { get; set; }
}
