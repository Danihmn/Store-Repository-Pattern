namespace Store.Application.UseCases.Customer.Create;

public sealed record Response
    (Guid Id, DateTime? CreatedAt, DateTime? UpdatedAt, string Name, string Email, string? Phone);
