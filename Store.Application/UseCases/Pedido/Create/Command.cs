using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Pedido.Create;

public sealed record Command (decimal Total, Guid ClienteId, Guid EnderecoId) : IRequest<Result<Response>>;
