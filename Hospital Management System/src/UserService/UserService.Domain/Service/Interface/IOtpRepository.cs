using System;
using UserService.Domain.Entity;

namespace UserService.Domain.Service.Interface;

public interface IOtpRepository

{
    Task CreateOtp(EOTP model);
    Task<EOTP> GetOtpByUserIdAndOtpType(Guid UserId, OTPType oTPType);
}
