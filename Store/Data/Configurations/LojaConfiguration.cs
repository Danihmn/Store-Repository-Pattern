using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Models;

namespace Store.Data.Configurations;

public class LojaConfiguration : IEntityTypeConfiguration<Loja>
{
    public void Configure (EntityTypeBuilder<Loja> builder)
    {
        builder.HasKey(e => e.Id).HasName("pk_lojas");

        builder.ToTable("lojas", "loja");

        builder.HasIndex(e => e.Cnpj, "uq_lojas_cnpj").IsUnique();

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
        builder.Property(e => e.RazaoSocial)
            .HasMaxLength(200)
            .HasColumnName("razao_social");
        builder.Property(e => e.NomeFantasia)
            .HasMaxLength(200)
            .HasColumnName("nome_fantasia");
        builder.Property(e => e.Cnpj)
            .HasMaxLength(14)
            .IsFixedLength()
            .HasColumnName("cnpj");
        builder.Property(e => e.Ativo)
            .HasDefaultValue(true)
            .HasColumnName("ativo");
        builder.Property(e => e.EnderecoId)
            .HasColumnName("id_endereco");
    }
}
