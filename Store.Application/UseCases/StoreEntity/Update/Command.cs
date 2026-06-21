using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.StoreEntity.Update;

public sealed record Command
    (Guid Id, string LegalName, string? TradeName, string Cnpj, bool Active, Guid AddressId) : IRequest<Result<Response>>;
