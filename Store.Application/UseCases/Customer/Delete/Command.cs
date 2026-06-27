using FluentResults;
using MediatR;

namespace Store.Application.UseCases.Customer.Delete;

public sealed record Command (Guid Id) : IRequest<Result>;
