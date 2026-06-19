using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Cliente.Update;

public sealed record Command (Guid Id, string Nome, string Email, string? Telefone) : IRequest<Result<Response>>;
