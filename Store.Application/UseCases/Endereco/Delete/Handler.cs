using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Endereco.Delete;

public sealed class Handler (IEnderecoRepository repository) : IRequestHandler<Command, Result>
{
    public async Task<Result> Handle (Command request, CancellationToken cancellationToken)
    {
        var endereco = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (endereco is null)
            return Result.Failure(new Error("404", "Endereço não encontrado"));

        await repository.DeleteAsync(request.Id, cancellationToken);

        return Result.Success();
    }
}
