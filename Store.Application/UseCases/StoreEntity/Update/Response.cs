namespace Store.Application.UseCases.StoreEntity.Update;

public sealed record Response
    (Guid Id, DateTime? CreatedAt, DateTime? UpdatedAt, string LegalName, string? TradeName, string Cnpj, bool Active, Guid AddressId);
