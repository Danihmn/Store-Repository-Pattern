using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Pedido.Update;

public sealed record Command
    (Guid Id, string? Status, decimal Total, Guid ClienteId, Guid EnderecoId) : IRequest<Result<Response>>;
