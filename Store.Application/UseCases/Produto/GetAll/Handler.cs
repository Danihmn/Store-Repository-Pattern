using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Produto.GetAll;

public sealed class Handler (IProdutoRepository repository) : IRequestHandler<Command, Result<IEnumerable<Response>>>
{
    public async Task<Result<IEnumerable<Response>>> Handle (Command request, CancellationToken cancellationToken)
    {
        var produtos = await repository.GetAllAsync(request.Skip, request.Take, cancellationToken);

        if (produtos is null || !produtos.Any())
            return Result.Failure<IEnumerable<Response>>(new Error("404", "Nenhum produto encontrado"));

        var responses = produtos.Select(p => new Response(
            Id: p.Id,
            CriadoEm: p.CriadoEm,
            AtualizadoEm: p.AtualizadoEm,
            Descricao: p.Descricao,
            PrecoUnitario: p.PrecoUnitario,
            Estoque: p.Estoque));

        return Result.Success(responses);
    }
}
