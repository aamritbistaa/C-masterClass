using System;
using DapperTestProject.Enum;

namespace DapperTestProject.View;

public class UserView
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public Status Status { get; set; }
    public DateTime Date { get; set; }
}
