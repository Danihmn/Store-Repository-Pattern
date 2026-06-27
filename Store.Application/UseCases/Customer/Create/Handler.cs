using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Customer.Create;

public sealed class Handler (ICustomerRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var customer = new Store.Domain.Entities.Customer(request.Name, request.Email, request.Phone);
        var created = await repository.CreateAsync(customer, cancellationToken);

        return Result.Success(new Response(
            Id: created.Id,
            CreatedAt: created.CreatedAt,
            UpdatedAt: created.UpdatedAt,
            Name: created.Name,
            Email: created.Email.Value,
            Phone: created.Phone.Value));
    }
}
