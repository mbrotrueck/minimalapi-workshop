
using System.Data;
using FluentValidation;
using Microsoft.Data.Sqlite;
using MinimalApiWorkshop.Filter.Dotnet6.Customers;
using MinimalApiWorkshop.Filter.Dotnet6.Models;
using MinimalApiWorkshop.Filter.Dotnet6.Validation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCustomerServices();
builder.Services.AddScoped<IValidator<Customer>, CustomerValidator>();

var app = builder.Build();

app.MapCustomerEndpoints();

app.Run("http://localhost:5001");

