namespace Store.Application.UseCases.StoreEntity.GetById;

public sealed record Response
    (Guid Id, DateTime? CreatedAt, DateTime? UpdatedAt, string LegalName, string? TradeName, string Cnpj, bool Active, Guid AddressId);
