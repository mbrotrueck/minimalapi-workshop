﻿namespace MinimalApiWorkshop.Strukturierung.Mediator.Models;

public class Customer
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public string FullName { get; init; } = default!;
}
