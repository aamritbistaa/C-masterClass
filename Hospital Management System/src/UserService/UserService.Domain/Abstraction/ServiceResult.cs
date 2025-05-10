using System;

namespace UserService.Domain.Abstraction;

public class ServiceResult<T> where T : class
{
    public T Data { get; set; }
    public string Message { get; set; }
    public int StatusCode { get; set; }
}
