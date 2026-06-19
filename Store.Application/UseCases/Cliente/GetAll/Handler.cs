using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Cliente.GetAll;

public sealed class Handler (IClienteRepository repository) : IRequestHandler<Command, Result<IEnumerable<Response>>>
{
    public async Task<Result<IEnumerable<Response>>> Handle (Command request, CancellationToken cancellationToken)
    {
        var clientes = await repository.GetAllAsync(request.Skip, request.Take, cancellationToken);

        if (clientes is null || !clientes.Any())
            return Result.Failure<IEnumerable<Response>>(new Error("404", "Nenhum cliente encontrado"));

        var responses = clientes.Select(cliente => new Response(
            Id: cliente.Id,
            CriadoEm: cliente.CriadoEm,
            AtualizadoEm: cliente.AtualizadoEm,
            Nome: cliente.Nome,
            Email: cliente.Email,
            Telefone: cliente.Telefone));

        return Result.Success(responses);
    }
}
