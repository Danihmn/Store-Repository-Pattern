namespace Store.Application.UseCases.ProdutoPedido.GetByPedidoId;

public sealed record Response (Guid PedidoId, Guid ProdutoId, int Quantidade);
