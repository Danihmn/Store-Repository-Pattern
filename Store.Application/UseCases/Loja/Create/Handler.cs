using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;

namespace Store.Application.UseCases.Loja.Create;

public sealed class Handler (ILojaRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle (Command request, CancellationToken cancellationToken)
    {
        var loja = new Store.Domain.Entities.Loja
        {
            RazaoSocial = request.RazaoSocial,
            NomeFantasia = request.NomeFantasia,
            Cnpj = request.Cnpj,
            Ativo = request.Ativo,
            EnderecoId = request.EnderecoId,
            CriadoEm = DateTime.UtcNow
        };

        var created = await repository.CreateAsync(loja, cancellationToken);

        return Result.Success(new Response(
            Id: created.Id,
            CriadoEm: created.CriadoEm,
            AtualizadoEm: created.AtualizadoEm,
            RazaoSocial: created.RazaoSocial,
            NomeFantasia: created.NomeFantasia,
            Cnpj: created.Cnpj,
            Ativo: created.Ativo,
            EnderecoId: created.EnderecoId));
    }
}
