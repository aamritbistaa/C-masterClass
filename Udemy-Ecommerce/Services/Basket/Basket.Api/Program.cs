using Basket.Api.Data;
using BuildingBlocks.Exception.Handler;
using BuildingBlocks.Middleware;
using Marten;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    config.AddOpenBehavior(typeof(RequestResponseLogging<,>));
});

var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new Exception("Connection string not found");

DatabaseExist.EnsureDatabaseExists(connectionString);

builder.Services.AddMarten(config =>
{
    config.Connection(connectionString);
    config.Schema.For<ShoppingCart>().Identity(x => x.UserName);
}).UseLightweightSessions();

builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.Decorate<IBasketRepository, CachedBasketRepository>();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder
    .Configuration.GetConnectionString("Redis");
});

//global exception handler
builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapCarter();

//global exception handler
app.UseExceptionHandler(opt => { });

app.Run();
