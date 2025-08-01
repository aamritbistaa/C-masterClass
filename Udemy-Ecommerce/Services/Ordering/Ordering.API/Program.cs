using Microsoft.EntityFrameworkCore;
using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

builder.Services.AddApplicationServices(builder.Configuration)
.AddInfrastructureServices(builder.Configuration)
.AddApiService(builder.Configuration);

var app = builder.Build();

//configure the http request pipeline
app.UserApiServies();
if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.Run();
