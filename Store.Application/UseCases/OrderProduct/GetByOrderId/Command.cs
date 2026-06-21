using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.OrderProduct.GetByOrderId;

public sealed record Command (Guid OrderId) : IRequest<Result<IEnumerable<Response>>>;
