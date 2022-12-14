using MinimalApiWorkshop.Strukturierung.Reflection.Models;
using MinimalApiWorkshop.Strukturierung.Reflection.Services;

namespace MinimalApiWorkshop.Strukturierung.Reflection.EndpointDefinitions;

public class CustomerEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/customers", GetAllCustomers);
        app.MapGet("/customers/{id}", GetCustomerById);
        app.MapPost("/customers", CreateCustomer);
        app.MapPut("/customers/{id}", UpdateCustomer);
        app.MapDelete("/customers/{id}", DeleteCustomerById);
    }

    internal List<Customer> GetAllCustomers(ICustomerService service)
    {
        return service.GetAll();
    }

    internal IResult GetCustomerById(ICustomerService service, Guid id)
    {
        var customer = service.GetById(id);
        return customer is not null ? Results.Ok(customer) : Results.NotFound();
    }

    internal IResult CreateCustomer(ICustomerService service, Customer customer)
    {
        service.Create(customer);
        return Results.Created($"/customers/{customer.Id}", customer);
    }

    internal IResult UpdateCustomer(ICustomerService service, Guid id, Customer updatedCustomer)
    {
        var customer = service.GetById(id);
        if (customer is null)
        {
            return Results.NotFound();
        }

        customer.FullName = updatedCustomer.FullName;
        service.Update(customer);
        return Results.Ok(customer);
    }

    internal IResult DeleteCustomerById(ICustomerService service, Guid id)
    {
        service.Delete(id);
        return Results.Ok();
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddSingleton<ICustomerService, CustomerService>();
    }
}