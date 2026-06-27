using FluentResults;
using MediatR;

namespace Store.Application.UseCases.StoreEntity.GetById;

public sealed record Command (Guid Id) : IRequest<Result<Response>>;
