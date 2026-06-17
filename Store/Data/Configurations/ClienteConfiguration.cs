using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Models;

namespace Store.Data.Configurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure (EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(e => e.Id).HasName("pk_clientes");

        builder.ToTable("clientes", "loja");

        builder.HasIndex(e => e.Email, "uq_clientes_email").IsUnique();
        builder.HasIndex(e => e.Telefone, "uq_clientes_telefone").IsUnique();

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
        builder.Property(e => e.Nome)
            .HasMaxLength(100)
            .HasColumnName("nome");
        builder.Property(e => e.Email)
            .HasMaxLength(150)
            .HasColumnName("email");
        builder.Property(e => e.Telefone)
            .HasMaxLength(20)
            .HasColumnName("telefone");
    }
}
