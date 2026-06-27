using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Data.Mappings;

public class OrderMapping : IEntityTypeConfiguration<Order>
{
    public void Configure (EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(e => e.Id).HasName("pk_orders");

        builder.ToTable("orders", "store");

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
        builder.Property(e => e.CustomerId)
            .HasColumnName("customer_id");
        builder.Property(e => e.AddressId)
            .HasColumnName("address_id");
        builder.Property(e => e.Status)
            .HasMaxLength(20)
            .HasDefaultValueSql("'pending'::character varying")
            .HasColumnName("status");
        builder.Property(e => e.Total)
            .HasPrecision(10, 2)
            .HasColumnName("total");
    }
}
