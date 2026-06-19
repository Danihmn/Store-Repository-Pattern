using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Loja.GetAll;

public sealed class Handler (ILojaRepository repository) : IRequestHandler<Command, Result<IEnumerable<Response>>>
{
    public async Task<Result<IEnumerable<Response>>> Handle (Command request, CancellationToken cancellationToken)
    {
        var lojas = await repository.GetAllAsync(request.Skip, request.Take, cancellationToken);

        if (lojas is null || !lojas.Any())
            return Result.Failure<IEnumerable<Response>>(new Error("404", "Nenhuma loja encontrada"));

        var responses = lojas.Select(l => new Response(
            Id: l.Id,
            CriadoEm: l.CriadoEm,
            AtualizadoEm: l.AtualizadoEm,
            RazaoSocial: l.RazaoSocial,
            NomeFantasia: l.NomeFantasia,
            Cnpj: l.Cnpj,
            Ativo: l.Ativo,
            EnderecoId: l.EnderecoId));

        return Result.Success(responses);
    }
}
