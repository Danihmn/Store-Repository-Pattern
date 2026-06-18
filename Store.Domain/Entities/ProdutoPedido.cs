namespace Store.Domain.Entities;

public class ProdutoPedido
{
    public Guid PedidoId { get; set; }
    public Guid ProdutoId { get; set; }
    public int Quantidade { get; set; }
}