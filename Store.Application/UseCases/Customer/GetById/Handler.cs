using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Customer.GetById;

public sealed class Handler (ICustomerRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var customer = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (customer is null)
            return Result.Failure<Response>(new Error("404", "Customer not found"));

        return Result.Success(new Response(
            Id: customer.Id,
            CreatedAt: customer.CreatedAt,
            UpdatedAt: customer.UpdatedAt,
            Name: customer.Name,
            Email: customer.Email.Value,
            Phone: customer.Phone.Value));
    }
}
