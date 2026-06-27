using FluentResults;
using MediatR;

namespace Store.Application.UseCases.Order.GetById;

public sealed record Command (Guid Id) : IRequest<Result<Response>>;
