using System;
using DapperTestProject.Enum;

namespace DapperTestProject.Entity;

public class EUsers
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public Status Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
}
