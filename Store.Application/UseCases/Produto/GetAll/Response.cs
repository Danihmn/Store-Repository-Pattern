namespace Store.Application.UseCases.Produto.GetAll;

public sealed record Response
    (Guid Id, DateTime? CriadoEm, DateTime? AtualizadoEm, string Descricao, decimal PrecoUnitario, int? Estoque);
