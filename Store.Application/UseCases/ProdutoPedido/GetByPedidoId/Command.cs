using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.ProdutoPedido.GetByPedidoId;

public sealed record Command (Guid PedidoId) : IRequest<Result<IEnumerable<Response>>>;
