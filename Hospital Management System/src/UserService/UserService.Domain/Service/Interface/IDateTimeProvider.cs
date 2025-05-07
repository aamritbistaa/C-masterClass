using System;

namespace UserService.Domain.Service.Interface;

public interface IDateTimeProvider
{
    DateTime CurrentDate { get; }
}
