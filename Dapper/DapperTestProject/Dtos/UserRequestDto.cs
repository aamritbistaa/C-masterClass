using System;
using DapperTestProject.Enum;

namespace DapperTestProject.Dtos;

public class UserRequestDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public Status Status { get; set; }
}
