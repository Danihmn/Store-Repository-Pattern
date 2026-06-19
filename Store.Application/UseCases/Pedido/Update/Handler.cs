using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Pedido.Update;

public sealed class Handler (IPedidoRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var pedido = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (pedido is null)
            return Result.Failure<Response>(new Error("404", "Pedido não encontrado"));

        pedido.Status = request.Status;
        pedido.Total = request.Total;
        pedido.ClienteId = request.ClienteId;
        pedido.EnderecoId = request.EnderecoId;
        pedido.AtualizadoEm = DateTime.UtcNow;

        var updated = await repository.UpdateAsync(pedido, cancellationToken);

        return Result.Success(new Response(
            Id: updated.Id,
            CriadoEm: updated.CriadoEm,
            AtualizadoEm: updated.AtualizadoEm,
            Status: updated.Status,
            Total: updated.Total,
            ClienteId: updated.ClienteId,
            EnderecoId: updated.EnderecoId));
    }
}
