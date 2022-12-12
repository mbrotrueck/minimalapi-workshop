using FluentValidation;
using MinimalApiWorkshop.Filter.Dotnet6.Models;

namespace MinimalApiWorkshop.Filter.Dotnet6.Validation;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
        
        RuleFor(x => x.Username)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(32);

        RuleFor(x => x.DateOfBirth)
            .LessThan(DateTime.Now.AddDays(1))
            .WithMessage(@"'DateOfBirth' darf nicht in der Zukunft liegen.");
    }
}