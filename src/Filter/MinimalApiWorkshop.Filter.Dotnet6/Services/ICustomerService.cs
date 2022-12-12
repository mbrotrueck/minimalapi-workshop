using MinimalApiWorkshop.Filter.Dotnet6.Models;

namespace MinimalApiWorkshop.Filter.Dotnet6.Services;

public interface ICustomerService
{
    void Create(Customer? customer);

    Customer? GetById(Guid id);

    List<Customer> GetAll();

    void Update(Customer customer);

    void Delete(Guid id);
}
