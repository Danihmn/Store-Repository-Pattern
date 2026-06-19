using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Endereco.Create;

public sealed record Command (string Rua, string Cidade, string Estado, string Cep) : IRequest<Result<Response>>;
