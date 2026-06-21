namespace Store.Application.UseCases.Order.Create;

public sealed record Response
    (Guid Id, DateTime? CreatedAt, DateTime? UpdatedAt, string? Status, decimal Total, Guid CustomerId, Guid AddressId);
