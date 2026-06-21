using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Customer.Delete;

public sealed record Command (Guid Id) : IRequest<Result>;
