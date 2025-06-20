using System;
using System.Net;
using System.Net.Mail;

namespace Hangfire_Test.Helper;

public interface IEmail
{
    Task SendMailAsync(string to, string subject, string body);
}
public class Email : IEmail
{
    private readonly string _email;
    private readonly string _password;

    public Email(IConfiguration config)
    {
        _email = config["EmailCredentials:username"];
        _password = config["EmailCredentials:password"];
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
            Console.WriteLine($"SMTP Error: {ex.StatusCode} - {ex.Message}");
            throw new Exception($"SMTP Error: {ex.StatusCode} - {ex.Message}");

        }
        catch (Exception ex)
        {

            Console.WriteLine($"{ex.Message}");
            throw new Exception(ex.Message);
        }
    }

}