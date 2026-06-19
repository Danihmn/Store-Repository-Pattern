using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Endereco.Create;

public sealed class Handler (IEnderecoRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var endereco = new Store.Domain.Entities.Endereco
        {
            Rua = request.Rua,
            Cidade = request.Cidade,
            Estado = request.Estado,
            Cep = request.Cep,
            CriadoEm = DateTime.UtcNow
        };

        var created = await repository.CreateAsync(endereco, cancellationToken);

        return Result.Success(new Response(
            Id: created.Id,
            CriadoEm: created.CriadoEm,
            AtualizadoEm: created.AtualizadoEm,
            Rua: created.Rua,
            Cidade: created.Cidade,
            Estado: created.Estado,
            Cep: created.Cep));
    }
}
