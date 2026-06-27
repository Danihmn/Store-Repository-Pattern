using FluentResults;
using MediatR;

namespace Store.Application.UseCases.OrderProduct.Delete;

public sealed record Command (Guid OrderId, Guid ProductId) : IRequest<Result>;
