namespace MinimalApiWorkshop.Strukturierung.ExtensionMethods.Customers;

public class Customer
{
    public Guid Id { get; } = Guid.NewGuid();

    public string FullName { get; set; } = string.Empty;
}
