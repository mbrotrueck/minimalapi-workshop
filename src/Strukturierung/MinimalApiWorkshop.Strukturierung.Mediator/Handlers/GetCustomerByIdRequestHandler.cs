using System.Text.Json.Serialization;
using MediatR;
using MinimalApiWorkshop.Strukturierung.Mediator.Services;

namespace MinimalApiWorkshop.Strukturierung.Mediator.Handlers;

public record GetCustomerByIdRequest : IRequest<IResult>
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }

    public GetCustomerByIdRequest(Guid id)
    {
        Id = id;
    }
}

public class GetCustomerByIdRequestHandler
    : IRequestHandler<GetCustomerByIdRequest, IResult>
{
    private readonly ICustomerService _customerService;

    public GetCustomerByIdRequestHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public Task<IResult> Handle(GetCustomerByIdRequest request, CancellationToken cancellationToken)
    {
        var customer = _customerService.GetById(request.Id);
        var response = customer is not null ? Results.Ok(customer) : Results.NotFound();
        return Task.FromResult(response);
    }
}
