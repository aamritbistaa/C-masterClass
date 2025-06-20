using Hangfire;
using Hangfire.PostgreSql;
using Hangfire_Test.Data;
using Hangfire_Test.Helper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new Exception("Connection string is null");

builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(connectionString));

builder.Services.AddHangfire(config =>
{
    config.UsePostgreSqlStorage(connectionString);
});
builder.Services.AddHangfireServer();

builder.Services.AddScoped<IVerifyAndSendEmail, VerifyAndSendEmail>();
builder.Services.AddScoped<IEmail, Email>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseHangfireDashboard("/dashboard");
app.UseHangfireServer();
app.Run();
