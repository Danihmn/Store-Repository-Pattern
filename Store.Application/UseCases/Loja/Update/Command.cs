using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Loja.Update;

public sealed record Command
    (Guid Id, string RazaoSocial, string? NomeFantasia, string Cnpj, bool Ativo, Guid EnderecoId) : IRequest<Result<Response>>;
