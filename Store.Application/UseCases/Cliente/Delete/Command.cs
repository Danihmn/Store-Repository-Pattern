using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Cliente.Delete;

public sealed record Command (Guid Id) : IRequest<Result>;
