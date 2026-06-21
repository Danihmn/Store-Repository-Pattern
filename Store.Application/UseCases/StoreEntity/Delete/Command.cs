using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.StoreEntity.Delete;

public sealed record Command (Guid Id) : IRequest<Result>;
