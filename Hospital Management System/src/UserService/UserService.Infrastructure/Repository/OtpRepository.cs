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
    public async Task UpdateOtp(EOTP model)
    {
        await base.UpdateAsync(model);
    }
    public async Task DeleteOtp(EOTP model)
    {
        await base.DeleteAsync(model);
    }

    public async Task<EOTP> GetOtpByUserIdAndOtpType(Guid UserId, OTPType oTPType)
    {
        var allOtp = await base.ListAsync();
        var data = allOtp.First(x => x.UserId == UserId && x.OTPType == oTPType);
        return data;
    }
    public async Task<string> GenerateOtp(OTPType screenType)
    {
        string OtpValue = "";

        var screenTypeString = Enum.GetName(typeof(OTPType), screenType);
        var otpString = (screenTypeString == null) ? "DE" : screenTypeString.ToUpper().Substring(0, 2);

        Random rnd = new Random();
        var otpNumber = rnd.Next(100, 1000);

        OtpValue = otpString + otpNumber;
        return OtpValue;
    }
}
