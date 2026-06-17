using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Models;

namespace Store.Data.Configurations;

public class ProdutosPedidoConfiguration : IEntityTypeConfiguration<ProdutosPedido>
{
    public void Configure (EntityTypeBuilder<ProdutosPedido> builder)
    {
        builder.HasKey(e => new { e.PedidoId, e.ProdutoId }).HasName("pk_produtos_pedidos");

        builder.ToTable("produtos_pedidos", "loja");

        builder.Property(e => e.PedidoId)
            .HasColumnName("pedido_id");
        builder.Property(e => e.ProdutoId)
            .HasColumnName("produto_id");
        builder.Property(e => e.Quantidade)
            .HasColumnName("quantidade");
    }
}
