using CleanArchitecture.Application;
using CleanArchitecture.Application.Manager.Implementation;
using CleanArchitecture.Application.Manager.Interface;
using CleanArchitecture.Application.Repository;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Infrastructure.Context;
using CleanArchitecture.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(opt=> opt.UseNpgsql(connectionString));
builder.Services.AddApplication();
builder.Services.AddScoped<IEmployeeService,EmployeeService>();
builder.Services.AddScoped(typeof(IEmployeeRepository<>), typeof(EmployeeRepository<>)); // Register the generic repository

var app = builder.Build();

EmployeeDbMigration.UpdateDatabase(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
