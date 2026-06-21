using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Data.Mappings;

public class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure (EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(e => e.Id).HasName("pk_customers");

        builder.ToTable("customers", "store");

        builder.HasIndex(e => e.Email, "uq_customers_email").IsUnique();
        builder.HasIndex(e => e.Phone, "uq_customers_phone").IsUnique();

        builder.Property(e => e.Id)
            .HasDefaultValueSql("gen_random_uuid()")
            .HasColumnName("id");
        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp without time zone")
            .HasColumnName("created_at");
        builder.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("now()")
            .HasColumnType("timestamp without time zone")
            .HasColumnName("updated_at");
        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .HasColumnName("name");
        builder.Property(e => e.Email)
            .HasMaxLength(150)
            .HasColumnName("email");
        builder.Property(e => e.Phone)
            .HasMaxLength(20)
            .HasColumnName("phone");
    }
}
