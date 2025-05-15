using System;
using UserService.Domain.Abstraction;

namespace UserService.Domain.Entity;

public class EUserDetail : BaseEntity
{
    public Guid UserId { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodGroup BloodGroup { get; set; }
    public string AdditionalContactNumber { get; set; }
}

public enum BloodGroup
{
    ABpos,
    ABneg,
    Apos,
    Aneg,
    Bpos,
    Bneg,
    Opos,
    Oneg,
}