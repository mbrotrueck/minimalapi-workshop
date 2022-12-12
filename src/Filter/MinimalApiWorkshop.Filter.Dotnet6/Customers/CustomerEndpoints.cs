using FluentValidation;
using MinimalApiWorkshop.Filter.Dotnet6.Models;
using MinimalApiWorkshop.Filter.Dotnet6.Services;

namespace MinimalApiWorkshop.Filter.Dotnet6.Customers;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this WebApplication app)
    {
        app.MapGet("/customers", GetAllCustomers);
        app.MapGet("/customers/{id}", GetCustomerById);
        app.MapPost("/customers", CreateCustomer);
        app.MapPut("/customers/{id}", UpdateCustomer);
        app.MapDelete("/customers/{id}", DeleteCustomerById);
    }

    public static void AddCustomerServices(this IServiceCollection services)
    {
        services.AddSingleton<ICustomerService, CustomerService>();
    }

    internal static List<Customer> GetAllCustomers(ICustomerService service)
    {
        return service.GetAll();
    }

    internal static IResult GetCustomerById(ICustomerService service, Guid id)
    {
        var customer = service.GetById(id);
        return customer is not null ? Results.Ok(customer) : Results.NotFound();
    }

    internal static async Task<IResult> CreateCustomer(ICustomerService service, IValidator<Customer> validator, Customer customer)
    {
        var result = await validator.ValidateAsync(customer);
        if (!result.IsValid)
        {
            return Results.BadRequest(result.Errors.ToResponse());
        }
        
        service.Create(customer);
        return Results.Created($"/customers/{customer.Id}", customer);
    }

    internal static IResult UpdateCustomer(ICustomerService service, Guid id, Customer updatedCustomer)
    {
        var customer = service.GetById(id);
        if (customer is null)
        {
            return Results.NotFound();
        }

        service.Update(customer);
        return Results.Ok(customer);
    }

    internal static IResult DeleteCustomerById(ICustomerService service, Guid id)
    {
        service.Delete(id);
        return Results.Ok();
    }
}
