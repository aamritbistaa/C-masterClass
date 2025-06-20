using System.Threading.Tasks;
using Hangfire;
using Hangfire_Test.Data;
using Hangfire_Test.Helper;
using Hangfire_Test.Models;
using Hangfire_Test.Properties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hangfire_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IEmail _email;

        public StudentController(ApplicationDbContext dbContext, IEmail email)
        {
            _dbContext = dbContext;
            _email = email;
        }

        [HttpGet]
        public async Task<List<Student>> GetStudents()
        {
            var result = await _dbContext.Students.ToListAsync();
            return result;
        }

        [HttpPost]
        public async Task<string> AddStudent(AddStudentRequestDto student)
        {

            var result = await _dbContext.Students.AddAsync(new Student()
            {
                CountryId = student.CountryId,
                DateOfBirth = student.DateOfBirth,
                IsApproved = false,
                Name = student.Name,
                Email = student.Email
            });
            await _dbContext.SaveChangesAsync();
            // _email.SendMailAsync(result.Entity.Email, "Added successfully", "Student details added");

            //Fire and forget
            var fireandFOrgetId = BackgroundJob.Enqueue("fireandforget", () => _email.SendMailAsync(result.Entity.Email, "Added successfully", "Student details added"));
            BackgroundJob.ContinueJobWith(fireandFOrgetId, () => _email.SendMailAsync(result.Entity.Email, "Onboading completed", "Welcome to the system"));

            //Create cron job to check if the user has not been approved in 10 min, automatically send email to the user.
            //Job that will run in 1min
            BackgroundJob.Schedule<IVerifyAndSendEmail>(x => x.SendEmail(result.Entity.Id), new DateTimeOffset(DateTime.Now.AddMinutes(1)));

            //Job that will run every 2 min
            RecurringJob.AddOrUpdate<IVerifyAndSendEmail>(
                recurringJobId: $"sendemail_{result.Entity.Id}",
                methodCall: x => x.SendEmail(result.Entity.Id),
                cronExpression: Cron.MinuteInterval(2)
            );
            return "Success";
        }

    }

}
