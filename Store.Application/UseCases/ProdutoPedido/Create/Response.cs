namespace Store.Application.UseCases.ProdutoPedido.Create;

public sealed record Response (Guid PedidoId, Guid ProdutoId, int Quantidade);
