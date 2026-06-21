using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Product.Delete;

public sealed record Command (Guid Id) : IRequest<Result>;
