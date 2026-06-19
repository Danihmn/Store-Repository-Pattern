using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Loja.Update;

public sealed class Handler (ILojaRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var loja = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (loja is null)
            return Result.Failure<Response>(new Error("404", "Loja não encontrada"));

        loja.RazaoSocial = request.RazaoSocial;
        loja.NomeFantasia = request.NomeFantasia;
        loja.Cnpj = request.Cnpj;
        loja.Ativo = request.Ativo;
        loja.EnderecoId = request.EnderecoId;
        loja.AtualizadoEm = DateTime.UtcNow;

        var updated = await repository.UpdateAsync(loja, cancellationToken);

        return Result.Success(new Response(
            Id: updated.Id,
            CriadoEm: updated.CriadoEm,
            AtualizadoEm: updated.AtualizadoEm,
            RazaoSocial: updated.RazaoSocial,
            NomeFantasia: updated.NomeFantasia,
            Cnpj: updated.Cnpj,
            Ativo: updated.Ativo,
            EnderecoId: updated.EnderecoId));
    }
}
