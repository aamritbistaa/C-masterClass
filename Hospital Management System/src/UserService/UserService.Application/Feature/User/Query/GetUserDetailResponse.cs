using System;

namespace UserService.Application.Feature.User.Query;

public class GetUserDetailResponse
{
    public DateTime DateOfBirth { get; set; }
    public string BloodGroup { get; set; }
    public string AdditionalContactNumber { get; set; }
}
