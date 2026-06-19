using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Data.Mappings;

public class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    public void Configure (EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(e => e.Id).HasName("pk_produtos");

        builder.ToTable("produtos", "catalogo");

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
        builder.Property(e => e.Descricao)
            .HasMaxLength(200)
            .HasColumnName("descricao");
        builder.Property(e => e.PrecoUnitario)
            .HasPrecision(10, 2)
            .HasColumnName("preco_unitario");
        builder.Property(e => e.Estoque)
            .HasDefaultValue(0)
            .HasColumnName("estoque");
    }
}
