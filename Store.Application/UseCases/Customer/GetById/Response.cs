namespace Store.Application.UseCases.Customer.GetById;

public sealed record Response
    (Guid Id, DateTime? CreatedAt, DateTime? UpdatedAt, string Name, string Email, string? Phone);
