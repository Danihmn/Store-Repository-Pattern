namespace Store.Application.UseCases.Cliente.GetById;

public sealed record Response
    (Guid Id, DateTime? CriadoEm, DateTime? AtualizadoEm, string Nome, string Email, string? Telefone);
