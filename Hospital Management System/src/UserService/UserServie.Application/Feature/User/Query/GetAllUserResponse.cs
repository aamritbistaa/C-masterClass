using System;

namespace UserServie.Application.Feature.User.Query;

public class GetAllUserResponse
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }

}
