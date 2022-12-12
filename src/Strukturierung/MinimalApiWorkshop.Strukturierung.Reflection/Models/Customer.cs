
namespace MinimalApiWorkshop.Strukturierung.Reflection.Models;

public class Customer
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public string FullName { get; set; } = string.Empty;
}