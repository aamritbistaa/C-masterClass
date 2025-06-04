
using Carter;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container for dependency injection

builder.Services.AddCarter();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});
var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new Exception("Connection string not found");
builder.Services.AddMarten(config =>
{
    config.Connection(connectionString);
}).UseLightweightSessions();
var app = builder.Build();

//Configure the HTTP request pipeline
app.MapCarter();
app.Run();
