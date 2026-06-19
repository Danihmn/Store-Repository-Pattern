using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Produto.Delete;

public sealed class Handler (IProdutoRepository repository) : IRequestHandler<Command, Result>
{
    public async Task<Result> Handle (Command request, CancellationToken cancellationToken)
    {
        var produto = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (produto is null)
            return Result.Failure(new Error("404", "Produto não encontrado"));

        await repository.DeleteAsync(request.Id, cancellationToken);

        return Result.Success();
    }
}
