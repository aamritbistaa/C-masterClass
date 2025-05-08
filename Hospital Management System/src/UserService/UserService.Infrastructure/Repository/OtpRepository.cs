using System;
using UserService.Domain.Entity;
using UserService.Domain.Service.Interface;
using UserService.Infrastructure.Data;

namespace UserService.Infrastructure.Repository;

public class OtpRepository : Repository<EOTP>, IOtpRepository
{
    public OtpRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task CreateOtp(EOTP model)
    {
        await base.AddAsync(model);
    }

    public async Task<EOTP> GetOtpByUserIdAndOtpType(Guid UserId, OTPType oTPType)
    {
        var allOtp = await base.ListAsync();
        var data = allOtp.First(x => x.UserId == UserId && x.OTPType == oTPType);
        return data;
    }
}
