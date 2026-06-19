using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Pedido.GetAll;

public sealed class Handler (IPedidoRepository repository) : IRequestHandler<Command, Result<IEnumerable<Response>>>
{
    public async Task<Result<IEnumerable<Response>>> Handle (Command request, CancellationToken cancellationToken)
    {
        var pedidos = await repository.GetAllAsync(request.Skip, request.Take, cancellationToken);

        if (pedidos is null || !pedidos.Any())
            return Result.Failure<IEnumerable<Response>>(new Error("404", "Nenhum pedido encontrado"));

        var responses = pedidos.Select(p => new Response(
            Id: p.Id,
            CriadoEm: p.CriadoEm,
            AtualizadoEm: p.AtualizadoEm,
            Status: p.Status,
            Total: p.Total,
            ClienteId: p.ClienteId,
            EnderecoId: p.EnderecoId));

        return Result.Success(responses);
    }
}
