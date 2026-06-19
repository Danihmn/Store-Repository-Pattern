namespace Store.Application.UseCases.ProdutoPedido.Update;

public sealed record Response (Guid PedidoId, Guid ProdutoId, int Quantidade);
