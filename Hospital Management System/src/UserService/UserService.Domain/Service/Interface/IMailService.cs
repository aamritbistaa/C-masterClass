using System;

namespace UserService.Domain.Service.Interface;

public interface IMailService
{
    Task SendMailAsync(string to, string subject, string body);
}
