
using Carter;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container for dependency injection

builder.Services.AddCarter();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

var app = builder.Build();

//Configure the HTTP request pipeline
app.MapCarter();
app.Run();
