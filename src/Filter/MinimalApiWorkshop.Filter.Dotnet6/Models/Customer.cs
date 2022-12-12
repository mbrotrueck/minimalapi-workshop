namespace MinimalApiWorkshop.Filter.Dotnet6.Models;

public class Customer
{
    public Guid Id { get; } = Guid.NewGuid();

    public string Username { get; init; } = default!;
    public string FullName { get; init; } = default!;
    public string Email { get; init; } = default!;
    public DateTime DateOfBirth { get; set; }
}
