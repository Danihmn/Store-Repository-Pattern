using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Cliente.Create;

public sealed class Handler (IClienteRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var cliente = new Store.Domain.Entities.Cliente
        {
            Nome = request.Nome,
            Email = request.Email,
            Telefone = request.Telefone,
            CriadoEm = DateTime.UtcNow
        };

        var created = await repository.CreateAsync(cliente, cancellationToken);

        return Result.Success(new Response(
            Id: created.Id,
            CriadoEm: created.CriadoEm,
            AtualizadoEm: created.AtualizadoEm,
            Nome: created.Nome,
            Email: created.Email,
            Telefone: created.Telefone));
    }
}
