using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Cliente.GetById;

public sealed class Handler (IClienteRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var cliente = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (cliente is null)
            return Result.Failure<Response>(new Error("404", "Cliente não encontrado"));

        return Result.Success(new Response(
            Id: cliente.Id,
            CriadoEm: cliente.CriadoEm,
            AtualizadoEm: cliente.AtualizadoEm,
            Nome: cliente.Nome,
            Email: cliente.Email,
            Telefone: cliente.Telefone));
    }
}
