using MediatR;
using MinimalApiWorkshop.Strukturierung.Mediator.Handlers;
using MinimalApiWorkshop.Strukturierung.Mediator.Models;
using MinimalApiWorkshop.Strukturierung.Mediator.Services;

var builder = WebApplication.CreateBuilder();

builder.Services.AddSingleton<ICustomerService, CustomerService>();
builder.Services.AddMediatR(typeof(Customer));
 
var app = builder.Build();

app.MapGet("customers", async (IMediator mediator) => await mediator.Send(new GetAllCustomersRequest()));
app.MapGet("/customers/{id}", async (IMediator mediator, Guid id) => await mediator.Send(new GetCustomerByIdRequest(id)));
app.MapPost("/customers", async (IMediator mediator, CreateCustomerRequest request) => await mediator.Send(request));
app.MapDelete("/customers/{id}", async (IMediator mediator, Guid id) => await mediator.Send(new DeleteCustomerByIdRequest(id)));

app.Run("http://localhost:5003");