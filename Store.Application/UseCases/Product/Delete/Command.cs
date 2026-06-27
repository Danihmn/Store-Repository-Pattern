using FluentResults;
using MediatR;

namespace Store.Application.UseCases.Product.Delete;

public sealed record Command (Guid Id) : IRequest<Result>;
