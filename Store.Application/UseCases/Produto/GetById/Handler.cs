using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Produto.GetById;

public sealed class Handler (IProdutoRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var product = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (product is null)
            return Result.Failure<Response>(new Error(Code: "404", Message: "Produto não encontrado"));

        return Result.Success(new Response(
            Id: product.Id,
            CriadoEm: product.CriadoEm,
            AtualizadoEm: product.AtualizadoEm,
            Descricao: product.Descricao,
            PrecoUnitario: product.PrecoUnitario,
            Estoque: product.Estoque));
    }
}