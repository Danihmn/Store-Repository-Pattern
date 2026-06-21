namespace Store.Application.UseCases.Order.GetAll;

public sealed record Response
    (Guid Id, DateTime? CreatedAt, DateTime? UpdatedAt, string? Status, decimal Total, Guid CustomerId, Guid AddressId);
