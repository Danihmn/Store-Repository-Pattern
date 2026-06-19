using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Produto.Create;

public sealed record Command (string Descricao, decimal PrecoUnitario, int? Estoque) : IRequest<Result<Response>>;
