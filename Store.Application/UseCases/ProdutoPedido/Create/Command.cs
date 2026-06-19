using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.ProdutoPedido.Create;

public sealed record Command (Guid PedidoId, Guid ProdutoId, int Quantidade) : IRequest<Result<Response>>;
