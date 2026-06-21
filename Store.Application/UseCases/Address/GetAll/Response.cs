namespace Store.Application.UseCases.Address.GetAll;

public sealed record Response
    (Guid Id, DateTime? CreatedAt, DateTime? UpdatedAt, string Street, string City, string State, string ZipCode);
