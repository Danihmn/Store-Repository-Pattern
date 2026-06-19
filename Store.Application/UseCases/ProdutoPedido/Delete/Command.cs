using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.ProdutoPedido.Delete;

public sealed record Command (Guid PedidoId, Guid ProdutoId) : IRequest<Result>;
