using System;
using UserService.Domain.Abstraction;
using UserService.Domain.Enum;

namespace UserService.Domain.Entity;

public class EUser : BaseEntity
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }
    public OnBoardingStatus OnBoardingStatus { get; set; }
}
public enum OnBoardingStatus
{
    NotStarted = 1,
    InProgress = 2,
    Rejected = 3,
    Completed = 4
}