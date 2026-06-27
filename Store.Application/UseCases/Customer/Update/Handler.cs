using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Customer.Update;

public sealed class Handler (ICustomerRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var customer = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (customer is null)
            return Result.Failure<Response>(new Error("404", "Customer not found"));

        customer.UpdateCustomer(request.Name, request.Email, request.Phone);

        var updated = await repository.UpdateAsync(customer, cancellationToken);

        return Result.Success(new Response(
            Id: updated.Id,
            CreatedAt: updated.CreatedAt,
            UpdatedAt: updated.UpdatedAt,
            Name: updated.Name,
            Email: updated.Email.Value,
            Phone: updated.Phone.Value));
    }
}
