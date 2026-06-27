using FluentResults;
using MediatR;

namespace Store.Application.UseCases.StoreEntity.GetAll;

public sealed record Command (int Skip = 0, int Take = 10) : IRequest<Result<IEnumerable<Response>>>;
