using System;

namespace UserServie.Application.Feature.User.Query;

public class GetUserResponse
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }

}
