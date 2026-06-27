using FluentResults;
using MediatR;

namespace Store.Application.UseCases.Address.Delete;

public sealed record Command (Guid Id) : IRequest<Result>;
