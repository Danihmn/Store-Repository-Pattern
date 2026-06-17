namespace Store.Models;

public partial class ProdutosPedido
{
    public Guid PedidoId { get; set; }

    public Guid ProdutoId { get; set; }

    public int Quantidade { get; set; }
}
