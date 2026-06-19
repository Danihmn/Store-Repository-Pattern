namespace Store.Application.UseCases.Loja.GetById;

public sealed record Response
    (Guid Id, DateTime? CriadoEm, DateTime? AtualizadoEm, string RazaoSocial, string? NomeFantasia, string Cnpj, bool Ativo, Guid EnderecoId);
