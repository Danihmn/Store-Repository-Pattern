using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Address.GetById;

public sealed record Command (Guid Id) : IRequest<Result<Response>>;
