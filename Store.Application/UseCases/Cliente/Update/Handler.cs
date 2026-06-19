using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Cliente.Update;

public sealed class Handler (IClienteRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var cliente = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (cliente is null)
            return Result.Failure<Response>(new Error("404", "Cliente não encontrado"));

        cliente.Nome = request.Nome;
        cliente.Email = request.Email;
        cliente.Telefone = request.Telefone;
        cliente.AtualizadoEm = DateTime.UtcNow;

        var updated = await repository.UpdateAsync(cliente, cancellationToken);

        return Result.Success(new Response(
            Id: updated.Id,
            CriadoEm: updated.CriadoEm,
            AtualizadoEm: updated.AtualizadoEm,
            Nome: updated.Nome,
            Email: updated.Email,
            Telefone: updated.Telefone));
    }
}
