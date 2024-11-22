using CQRSApplication.Context;
using CQRSApplication.Helpers;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Reflection;

namespace CQRSApplication
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CQRSDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("CQRSConnection"));
                options.EnableSensitiveDataLogging();
            });
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            // To use Email services
            services.AddScoped<EmailService>();

            //To access authentication header
            //Registering httpContext and injecting it globally
            services.AddHttpContextAccessor();
            services.AddScoped<HttpContextHelper>();
            
            services.AddHangfire(config =>
                config.UsePostgreSqlStorage(c =>
                        c.UseNpgsqlConnection(Configuration.GetConnectionString("CQRSHangfireDbPSQL"))
                    )
                );

            // Add the Hangfire server
            services.AddHangfireServer();
        }


        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
            //Hangfire
            app.UseHangfireDashboard();

            //            app.UseHangfireDashboard("/hangfire", new DashboardOptions()
            //            {
            //                DashboardTitle = "Hangfire Dashboard",
            //                Authorization = new[]{
            //    new HangfireCustomBasicAuthenticationFilter{
            //        User = Configuration.GetSection("HangfireCredentials:UserName").Value,
            //        Pass = Configuration.GetSection("HangfireCredentials:Password").Value
            //    }
            //});


            // app.UseHangfireDashboard("/hangfire", new DashboardOptions()
            // {
            //     DashboardTitle = "Hangfire Dashboard",
            // });

        }
    }
}
