using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Cliente.Create;

public sealed record Command (string Nome, string Email, string? Telefone) : IRequest<Result<Response>>;
