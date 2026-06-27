using FluentResults;
using MediatR;

namespace Store.Application.UseCases.Order.Delete;

public sealed record Command (Guid Id) : IRequest<Result>;
