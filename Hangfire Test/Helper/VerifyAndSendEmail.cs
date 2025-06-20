using System;
using Hangfire;
using Hangfire_Test.Data;
using Microsoft.EntityFrameworkCore;

namespace Hangfire_Test.Helper;

public interface IVerifyAndSendEmail
{
    Task SendEmail(int Id);
}
public class VerifyAndSendEmail : IVerifyAndSendEmail
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IEmail _mail;

    public VerifyAndSendEmail(ApplicationDbContext dbContext, IEmail mail)
    {
        _dbContext = dbContext;
        _mail = mail;
    }

    public async Task SendEmail(int Id)
    {
        var student = await _dbContext.Students
            .Where(x => x.Id == Id)
            .OrderBy(x => x.Id) // or OrderByDescending if needed
            .LastOrDefaultAsync();
        // Stop recurring job if approved
        if (student.IsApproved)
        {
            RecurringJob.RemoveIfExists($"sendemail_{Id}");
            return; // Skip sending email since approved
        }
        string message;
        if (student.IsApproved == true)
        {
            message = "Account has been approved";
        }
        else
        {
            message = "Account has not been approved";
        }
        await _mail.SendMailAsync(student.Email, "Signup", message);
    }
}
