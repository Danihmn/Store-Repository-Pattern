namespace Store.Application.UseCases.Product.Update;

public sealed record Response
    (Guid Id, DateTime? CreatedAt, DateTime? UpdatedAt, string Description, decimal UnitPrice, int? Stock);
