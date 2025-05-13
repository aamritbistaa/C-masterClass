using System;
using UserService.Domain.Entity;
using UserService.Domain.Enum;

namespace UserService.Api.Controllers;

public static class Common
{
    public static WebApplication Dropdown(this WebApplication app)
    {

        app.MapGet("/DropDown/OnBoardingStatus", () =>
        {
            var enumData = from OnBoardingStatus e in Enum.GetValues(typeof(OnBoardingStatus))
                           select new
                           {
                               ID = (int)e,
                               Name = e.ToString()
                           };
            return enumData;
        });

        app.MapGet("/DropDown/UserRole", () =>
        {
            var enumData = from UserRole e in Enum.GetValues(typeof(UserRole))
                           select new
                           {
                               ID = (int)e,
                               Name = e.ToString()
                           };
            return enumData;
        });

        app.MapGet("/DropDown/OtpType", () =>
        {
            var enumData = from OTPType e in Enum.GetValues(typeof(OTPType))
                           select new
                           {
                               ID = (int)e,
                               Name = e.ToString()
                           };
            return enumData;
        });

        return app;

    }
}
