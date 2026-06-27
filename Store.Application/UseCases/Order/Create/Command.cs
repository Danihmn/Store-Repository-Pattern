using FluentResults;
using MediatR;

namespace Store.Application.UseCases.Order.Create;

public sealed record Command (decimal Total, Guid CustomerId, Guid AddressId) : IRequest<Result<Response>>;
