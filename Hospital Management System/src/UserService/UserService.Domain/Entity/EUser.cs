using System;
using UserService.Domain.Abstraction;

namespace UserService.Domain.Entity;

public class EUser : BaseEntity
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
}
