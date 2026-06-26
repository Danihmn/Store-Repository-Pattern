using Store.Domain.Abstractions;

namespace Store.Domain.Entities;

public class Product : Entity
{
    public string Description { get; private set; } = null!;
    public decimal UnitPrice { get; private set; }
    public int? Stock { get; private set; }

    public Product (string description, decimal unitPrice, int? stock = null)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new InvalidOperationException("Description cannot be empty");

        if (unitPrice <= 0)
            throw new InvalidOperationException("UnitPrice must be greater than 0");

        if (stock < 0)
            throw new InvalidOperationException("Stock cannot be negative");

        Description = description;
        UnitPrice = unitPrice;
        Stock = stock;

        base.CreatedAt = DateTime.UtcNow;
        base.UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateProduct (string? description = null, decimal? unitPrice = null, int? stock = null)
    {
        if (description != null && string.IsNullOrWhiteSpace(description))
            throw new InvalidOperationException("Description cannot be empty");

        if (unitPrice != null && unitPrice <= 0)
            throw new InvalidOperationException("UnitPrice must be greater than 0");

        if (stock < 0)
            throw new InvalidOperationException("Stock cannot be negative");

        Description = description ?? Description;
        UnitPrice = unitPrice ?? UnitPrice;
        Stock = stock ?? Stock;

        base.UpdatedAt = DateTime.UtcNow;
    }
}
