using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Endereco.GetById;

public sealed record Command (Guid Id) : IRequest<Result<Response>>;
