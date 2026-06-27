using FluentResults;
using MediatR;

namespace Store.Application.UseCases.StoreEntity.Delete;

public sealed record Command (Guid Id) : IRequest<Result>;
