using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Endereco.Delete;

public sealed record Command (Guid Id) : IRequest<Result>;
