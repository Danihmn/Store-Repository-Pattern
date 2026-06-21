using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Order.Delete;

public sealed record Command (Guid Id) : IRequest<Result>;
