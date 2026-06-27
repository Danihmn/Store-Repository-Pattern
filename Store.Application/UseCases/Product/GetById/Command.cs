using FluentResults;
using MediatR;

namespace Store.Application.UseCases.Product.GetById;

public sealed record Command (Guid Id) : IRequest<Result<Response>>;
