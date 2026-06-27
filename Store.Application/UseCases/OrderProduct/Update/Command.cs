using FluentResults;
using MediatR;

namespace Store.Application.UseCases.OrderProduct.Update;

public sealed record Command (Guid OrderId, Guid ProductId, int Quantity) : IRequest<Result<Response>>;
