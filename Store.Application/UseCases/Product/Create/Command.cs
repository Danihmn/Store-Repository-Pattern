using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Product.Create;

public sealed record Command (string Description, decimal UnitPrice, int? Stock) : IRequest<Result<Response>>;
