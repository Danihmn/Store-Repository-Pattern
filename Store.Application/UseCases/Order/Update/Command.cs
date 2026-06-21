using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Order.Update;

public sealed record Command
    (Guid Id, string? Status, decimal Total, Guid CustomerId, Guid AddressId) : IRequest<Result<Response>>;
