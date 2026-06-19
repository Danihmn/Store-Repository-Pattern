using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Data.Mappings;

public class PedidoMapping : IEntityTypeConfiguration<Pedido>
{
    public void Configure (EntityTypeBuilder<Pedido> builder)
    {
        builder.HasKey(e => e.Id).HasName("pk_pedidos");

        builder.ToTable("pedidos", "loja");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("gen_random_uuid()")
            .HasColumnName("id");
        builder.Property(e => e.CriadoEm)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp without time zone")
            .HasColumnName("criado_em");
        builder.Property(e => e.AtualizadoEm)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp without time zone")
            .HasColumnName("atualizado_em");
        builder.Property(e => e.ClienteId)
            .HasColumnName("cliente_id");
        builder.Property(e => e.EnderecoId)
            .HasColumnName("endereco_id");
        builder.Property(e => e.Status)
            .HasMaxLength(20)
            .HasDefaultValueSql("'pendente'::character varying")
            .HasColumnName("status");
        builder.Property(e => e.Total)
            .HasPrecision(10, 2)
            .HasColumnName("total");
    }
}
