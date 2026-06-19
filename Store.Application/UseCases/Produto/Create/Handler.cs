using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Produto.Create;

public sealed class Handler (IProdutoRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var produto = new Store.Domain.Entities.Produto
        {
            Descricao = request.Descricao,
            PrecoUnitario = request.PrecoUnitario,
            Estoque = request.Estoque,
            CriadoEm = DateTime.UtcNow
        };

        var created = await repository.CreateAsync(produto, cancellationToken);

        return Result.Success(new Response(
            Id: created.Id,
            CriadoEm: created.CriadoEm,
            AtualizadoEm: created.AtualizadoEm,
            Descricao: created.Descricao,
            PrecoUnitario: created.PrecoUnitario,
            Estoque: created.Estoque));
    }
}
