using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Produto.Update;

public sealed class Handler (IProdutoRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var produto = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (produto is null)
            return Result.Failure<Response>(new Error("404", "Produto não encontrado"));

        produto.Descricao = request.Descricao;
        produto.PrecoUnitario = request.PrecoUnitario;
        produto.Estoque = request.Estoque;
        produto.AtualizadoEm = DateTime.UtcNow;

        var updated = await repository.UpdateAsync(produto, cancellationToken);

        return Result.Success(new Response(
            Id: updated.Id,
            CriadoEm: updated.CriadoEm,
            AtualizadoEm: updated.AtualizadoEm,
            Descricao: updated.Descricao,
            PrecoUnitario: updated.PrecoUnitario,
            Estoque: updated.Estoque));
    }
}
