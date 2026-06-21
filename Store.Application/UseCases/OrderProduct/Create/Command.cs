using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.OrderProduct.Create;

public sealed record Command (Guid OrderId, Guid ProductId, int Quantity) : IRequest<Result<Response>>;
