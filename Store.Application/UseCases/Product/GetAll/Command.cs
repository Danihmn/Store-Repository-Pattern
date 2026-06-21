using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Product.GetAll;

public sealed record Command (int Skip = 0, int Take = 10) : IRequest<Result<IEnumerable<Response>>>;
