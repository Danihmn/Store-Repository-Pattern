using FluentResults;
using MediatR;

namespace Store.Application.UseCases.StoreEntity.Create;

public sealed record Command
    (string LegalName, string? TradeName, string Cnpj, bool Active, Guid AddressId) : IRequest<Result<Response>>;
