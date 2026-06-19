namespace Store.Application.UseCases.Endereco.Create;

public sealed record Response
    (Guid Id, DateTime? CriadoEm, DateTime? AtualizadoEm, string Rua, string Cidade, string Estado, string Cep);
