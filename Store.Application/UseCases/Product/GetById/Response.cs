namespace Store.Application.UseCases.Product.GetById;

public sealed record Response
    (Guid Id, DateTime? CreatedAt, DateTime? UpdatedAt, string Description, decimal UnitPrice, int? Stock);
