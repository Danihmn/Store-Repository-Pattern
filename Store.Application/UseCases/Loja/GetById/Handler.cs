using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Loja.GetById;

public sealed class Handler (ILojaRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var loja = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (loja is null)
            return Result.Failure<Response>(new Error("404", "Loja não encontrada"));

        return Result.Success(new Response(
            Id: loja.Id,
            CriadoEm: loja.CriadoEm,
            AtualizadoEm: loja.AtualizadoEm,
            RazaoSocial: loja.RazaoSocial,
            NomeFantasia: loja.NomeFantasia,
            Cnpj: loja.Cnpj,
            Ativo: loja.Ativo,
            EnderecoId: loja.EnderecoId));
    }
}
