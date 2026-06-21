using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Data.Mappings;

internal class OrderProductMapping : IEntityTypeConfiguration<OrderProduct>
{
    public void Configure (EntityTypeBuilder<OrderProduct> builder)
    {
        builder.HasKey(e => new { e.OrderId, e.ProductId }).HasName("pk_order_products");

        builder.ToTable("order_products", "store");

        builder.Property(e => e.OrderId)
            .HasColumnName("order_id");
        builder.Property(e => e.ProductId)
            .HasColumnName("product_id");
        builder.Property(e => e.Quantity)
            .HasColumnName("quantity");
    }
}
