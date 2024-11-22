using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;

namespace CQRSApplication.Helpers
{
    public class EmailService
    {
        private readonly string _email;
        private readonly string _password;
        public EmailService(IConfiguration config)
        {
            _email = config["EmailCredentials:username"];
            _password = config["EmailCredentials:password"];
        }
        public async Task SendMail(string senderMail, string subject, string message)
        {
            try
            {
                using (var client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(_email, _password);
                    client.UseDefaultCredentials = false;

                    var mailMessage = new MailMessage(_email, senderMail, subject, message);
                    await client.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {
                Log.Error("An error occured while sending mail\n {@message}", ex.Message);
            }

            
        }
        public async Task UserRegisteredEmail(string email)
        {
            string subject = $"Welcome to BuyNinja";
            string message = $"User has been registered successfully to BuyNinja !";
            await SendMail(email, subject, message);
        }

        public async Task UnAuthenticatedUserTriedToLoggIn(string email)
        {
            string subject = "Unauthenticated user login detected";
            string message = $"Unknown person trying to login to BuyNinja !";
            await SendMail(email, subject, message);
        }

        public async Task UserLoggedInEmail(string email)
        {
            string subject = "Signed In to BuyNinja";
            string message = $"New Login to BuyNinja ! \nTry reseting passoword if it was not you.";
            await SendMail(email, subject, message);
        }
    }
}
