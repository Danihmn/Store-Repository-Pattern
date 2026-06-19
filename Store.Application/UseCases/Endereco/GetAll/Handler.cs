using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Endereco.GetAll;

public sealed class Handler (IEnderecoRepository repository) : IRequestHandler<Command, Result<IEnumerable<Response>>>
{
    public async Task<Result<IEnumerable<Response>>> Handle (Command request, CancellationToken cancellationToken)
    {
        var enderecos = await repository.GetAllAsync(request.Skip, request.Take, cancellationToken);

        if (enderecos is null || !enderecos.Any())
            return Result.Failure<IEnumerable<Response>>(new Error("404", "Nenhum endereço encontrado"));

        var responses = enderecos.Select(e => new Response(
            Id: e.Id,
            CriadoEm: e.CriadoEm,
            AtualizadoEm: e.AtualizadoEm,
            Rua: e.Rua,
            Cidade: e.Cidade,
            Estado: e.Estado,
            Cep: e.Cep));

        return Result.Success(responses);
    }
}
