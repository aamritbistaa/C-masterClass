using System;
using UserService.Domain.Service.Interface;

namespace UserService.Infrastructure.Clock;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime CurrentDate => DateTime.UtcNow;
}
