using FluentResults;
using MediatR;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Customer.Create;

public sealed class Handler (ICustomerRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var customer = Store.Domain.Entities.Customer.Create(request.Name, request.Email, request.Phone);
        var created = await repository.CreateAsync(customer.Value, cancellationToken);

        return Result.Ok(new Response(
            Id: created.Id,
            CreatedAt: created.CreatedAt,
            UpdatedAt: created.UpdatedAt,
            Name: created.Name,
            Email: created.Email.Value,
            Phone: created.Phone.Value));
    }
}
