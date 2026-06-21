using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Customer.GetAll;

public sealed class Handler (ICustomerRepository repository) : IRequestHandler<Command, Result<IEnumerable<Response>>>
{
    public async Task<Result<IEnumerable<Response>>> Handle (Command request, CancellationToken cancellationToken)
    {
        var customers = await repository.GetAllAsync(request.Skip, request.Take, cancellationToken);

        if (customers is null || !customers.Any())
            return Result.Failure<IEnumerable<Response>>(new Error("404", "No customers found"));

        var responses = customers.Select(c => new Response(
            Id: c.Id,
            CreatedAt: c.CreatedAt,
            UpdatedAt: c.UpdatedAt,
            Name: c.Name,
            Email: c.Email,
            Phone: c.Phone));

        return Result.Success(responses);
    }
}
