using FluentResults;
using MediatR;

namespace Store.Application.UseCases.Customer.GetById;

public sealed record Command (Guid Id) : IRequest<Result<Response>>;
