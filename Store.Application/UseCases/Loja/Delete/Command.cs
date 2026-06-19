using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Loja.Delete;

public sealed record Command (Guid Id) : IRequest<Result>;
