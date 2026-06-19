using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Loja.Create;

public sealed record Command
    (string RazaoSocial, string? NomeFantasia, string Cnpj, bool Ativo, Guid EnderecoId) : IRequest<Result<Response>>;
