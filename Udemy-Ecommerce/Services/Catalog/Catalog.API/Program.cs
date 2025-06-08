using Catalog.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container for dependency injection

builder.Services.AddCarter();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new Exception("Connection string not found");

DatabaseExist.EnsureDatabaseExists(connectionString);

builder.Services.AddMarten(config =>
{
    config.Connection(connectionString);
}).UseLightweightSessions();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
//Configure the HTTP request pipeline
app.MapCarter();
app.Run();
