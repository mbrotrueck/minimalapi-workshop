using MinimalApiWorkshop.Strukturierung.ExtensionMethods.Customers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomerServices();

var app = builder.Build();

app.MapCustomerEndpoints();

app.Run("http://localhost:5001");