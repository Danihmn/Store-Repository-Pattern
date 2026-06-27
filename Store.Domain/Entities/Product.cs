using FluentResults;
using Store.Domain.Abstractions;

namespace Store.Domain.Entities;

public class Product : Entity
{
    public string Description { get; private set; } = null!;
    public decimal UnitPrice { get; private set; }
    public int? Stock { get; private set; }

    private Product (string description, decimal unitPrice, int? stock)
    {
        Description = description;
        UnitPrice = unitPrice;
        Stock = stock;

        base.CreatedAt = DateTime.UtcNow;
        base.UpdatedAt = DateTime.UtcNow;
    }

    public static Result<Product> Create (string description, decimal unitPrice, int? stock = null)
    {
        var errors = new List<IError>();

        if (string.IsNullOrWhiteSpace(description))
            errors.Add(new Abstractions.Error("InvalidDescription", "Description cannot be empty"));

        if (unitPrice <= 0)
            errors.Add(new Abstractions.Error("InvalidUnitPrice", "UnitPrice must be greater than 0"));

        if (stock < 0)
            errors.Add(new Abstractions.Error("InvalidStock", "Stock cannot be negative"));

        if (errors.Count > 0)
            return Result.Fail<Product>(errors);

        return Result.Ok(new Product(description, unitPrice, stock));
    }

    public Result UpdateProduct (string? description = null, decimal? unitPrice = null, int? stock = null)
    {
        var errors = new List<IError>();

        if (description != null && string.IsNullOrWhiteSpace(description))
            errors.Add(new Abstractions.Error("InvalidDescription", "Description cannot be empty"));

        if (unitPrice != null && unitPrice <= 0)
            errors.Add(new Abstractions.Error("InvalidUnitPrice", "UnitPrice must be greater than 0"));

        if (stock < 0)
            errors.Add(new Abstractions.Error("InvalidStock", "Stock cannot be negative"));

        if (errors.Count > 0)
            return Result.Fail(errors);

        Description = description ?? Description;
        UnitPrice = unitPrice ?? UnitPrice;
        Stock = stock ?? Stock;

        base.UpdatedAt = DateTime.UtcNow;
        return Result.Ok();
    }
}
