using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Endereco.GetById;

public sealed class Handler (IEnderecoRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var endereco = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (endereco is null)
            return Result.Failure<Response>(new Error("404", "Endereço não encontrado"));

        return Result.Success(new Response(
            Id: endereco.Id,
            CriadoEm: endereco.CriadoEm,
            AtualizadoEm: endereco.AtualizadoEm,
            Rua: endereco.Rua,
            Cidade: endereco.Cidade,
            Estado: endereco.Estado,
            Cep: endereco.Cep));
    }
}
