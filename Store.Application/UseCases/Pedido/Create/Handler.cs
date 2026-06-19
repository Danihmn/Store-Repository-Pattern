using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Pedido.Create;

public sealed class Handler (IPedidoRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var pedido = new Store.Domain.Entities.Pedido
        {
            Status = "pendente",
            Total = request.Total,
            ClienteId = request.ClienteId,
            EnderecoId = request.EnderecoId,
            CriadoEm = DateTime.UtcNow
        };

        var created = await repository.CreateAsync(pedido, cancellationToken);

        return Result.Success(new Response(
            Id: created.Id,
            CriadoEm: created.CriadoEm,
            AtualizadoEm: created.AtualizadoEm,
            Status: created.Status,
            Total: created.Total,
            ClienteId: created.ClienteId,
            EnderecoId: created.EnderecoId));
    }
}
