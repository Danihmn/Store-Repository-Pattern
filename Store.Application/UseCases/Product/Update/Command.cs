using FluentResults;
using MediatR;

namespace Store.Application.UseCases.Product.Update;

public sealed record Command (Guid Id, string Description, decimal UnitPrice, int? Stock) : IRequest<Result<Response>>;
