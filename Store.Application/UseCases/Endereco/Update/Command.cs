using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Endereco.Update;

public sealed record Command (Guid Id, string Rua, string Cidade, string Estado, string Cep) : IRequest<Result<Response>>;
