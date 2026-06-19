using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Cliente.Delete;

public sealed class Handler (IClienteRepository repository) : IRequestHandler<Command, Result>
{
    public async Task<Result> Handle (Command request, CancellationToken cancellationToken)
    {
        var cliente = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (cliente is null)
            return Result.Failure(new Error("404", "Cliente não encontrado"));

        await repository.DeleteAsync(request.Id, cancellationToken);

        return Result.Success();
    }
}
