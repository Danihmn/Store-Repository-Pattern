using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Loja.Delete;

public sealed class Handler (ILojaRepository repository) : IRequestHandler<Command, Result>
{
    public async Task<Result> Handle (Command request, CancellationToken cancellationToken)
    {
        var loja = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (loja is null)
            return Result.Failure(new Error("404", "Loja não encontrada"));

        await repository.DeleteAsync(request.Id, cancellationToken);

        return Result.Success();
    }
}
