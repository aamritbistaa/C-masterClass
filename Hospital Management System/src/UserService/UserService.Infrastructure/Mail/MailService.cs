using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Serilog;
using UserService.Domain.Service.Interface;

namespace UserService.Infrastructure.Mail;

public class MailService : IMailService
{
    private readonly ILogger _logger;
    private readonly string _email;
    private readonly string _password;

    public MailService(IConfiguration config, ILogger logger)
    {
        _email = config["EmailCredentials:username"];
        _password = config["EmailCredentials:password"];
        _logger = logger;
    }
    public async Task SendMailAsync(string to, string subject, string body)
    {
        try
        {
            using (var client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(_email, _password);
                client.UseDefaultCredentials = false;

                var mailMessage = new MailMessage(_email, to, subject, body);
                await client.SendMailAsync(mailMessage);
            }
        }
        catch (SmtpException ex)
        {
            _logger.Error($"SMTP Error: {ex.StatusCode} - {ex.Message}");
        }
        catch (Exception ex)
        {
            _logger.Error("An error occurred while sending mail: {@Message}", ex.Message);
        }
    }
}
