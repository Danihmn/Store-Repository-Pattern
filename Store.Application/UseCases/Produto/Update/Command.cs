using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Produto.Update;

public sealed record Command (Guid Id, string Descricao, decimal PrecoUnitario, int? Estoque) : IRequest<Result<Response>>;
