using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
namespace UserServie.Application.Common;

public static class CommonClass
{
    public static string GetName(string firstName, string middleName, string lastName)
    {
        return string.IsNullOrEmpty(middleName)
            ? $"{firstName} {lastName}"
            : $"{firstName} {middleName} {lastName}";
    }
}