using System;

namespace UserService.Domain.Service;

public class ConcurrencyException : Exception
{
    public ConcurrencyException(string message, Exception innerException) : base(message, innerException)
    {
        Console.WriteLine(message, innerException.Message);
    }
}
