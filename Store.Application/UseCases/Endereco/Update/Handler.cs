using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Endereco.Update;

public sealed class Handler (IEnderecoRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var endereco = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (endereco is null)
            return Result.Failure<Response>(new Error("404", "Endereço não encontrado"));

        endereco.Rua = request.Rua;
        endereco.Cidade = request.Cidade;
        endereco.Estado = request.Estado;
        endereco.Cep = request.Cep;
        endereco.AtualizadoEm = DateTime.UtcNow;

        var updated = await repository.UpdateAsync(endereco, cancellationToken);

        return Result.Success(new Response(
            Id: updated.Id,
            CriadoEm: updated.CriadoEm,
            AtualizadoEm: updated.AtualizadoEm,
            Rua: updated.Rua,
            Cidade: updated.Cidade,
            Estado: updated.Estado,
            Cep: updated.Cep));
    }
}
