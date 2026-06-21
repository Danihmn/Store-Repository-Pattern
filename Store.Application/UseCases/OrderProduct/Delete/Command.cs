using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.OrderProduct.Delete;

public sealed record Command (Guid OrderId, Guid ProductId) : IRequest<Result>;
