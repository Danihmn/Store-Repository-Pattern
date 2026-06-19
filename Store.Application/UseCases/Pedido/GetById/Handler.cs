using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Pedido.GetById;

public sealed class Handler (IPedidoRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var pedido = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (pedido is null)
            return Result.Failure<Response>(new Error("404", "Pedido não encontrado"));

        return Result.Success(new Response(
            Id: pedido.Id,
            CriadoEm: pedido.CriadoEm,
            AtualizadoEm: pedido.AtualizadoEm,
            Status: pedido.Status,
            Total: pedido.Total,
            ClienteId: pedido.ClienteId,
            EnderecoId: pedido.EnderecoId));
    }
}
