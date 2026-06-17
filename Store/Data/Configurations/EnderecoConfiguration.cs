using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Models;

namespace Store.Data.Configurations;

public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure (EntityTypeBuilder<Endereco> builder)
    {
        builder.HasKey(e => e.Id).HasName("pk_enderecos");

        builder.ToTable("enderecos", "loja");

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
        builder.Property(e => e.Rua)
            .HasMaxLength(200)
            .HasColumnName("rua");
        builder.Property(e => e.Cidade)
            .HasMaxLength(100)
            .HasColumnName("cidade");
        builder.Property(e => e.Estado)
            .HasMaxLength(2)
            .IsFixedLength()
            .HasColumnName("estado");
        builder.Property(e => e.Cep)
            .HasMaxLength(9)
            .HasColumnName("cep");
    }
}
