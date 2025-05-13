using System;
using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.Domain.Abstraction;
using UserService.Domain.Service.Interface;
using UserService.Infrastructure.Clock;
using UserService.Infrastructure.Data;
using UserService.Infrastructure.File;
using UserService.Infrastructure.Mail;
using UserService.Infrastructure.Repository;

namespace UserService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default") ?? throw new Exception("ConnectionString is null");
        service.AddDbContext<ApplicationDbContext>(config =>
        {
            config.UseNpgsql(connectionString);
        });

        // Extension.LoggerMethod();
        service.AddTransient<IUnitOfWork>(x => x.GetRequiredService<ApplicationDbContext>());

        service.AddScoped<IDateTimeProvider, DateTimeProvider>();
        service.AddScoped<IUserRepository, UserRepository>();
        service.AddScoped<IOtpRepository, OtpRepository>();
        service.AddScoped<IUserDocumentRepository, UserDocumentRepository>();


        service.AddScoped<IMailService, MailService>();
        service.AddScoped<IFileService, FileService>();
        return service;
    }
}
