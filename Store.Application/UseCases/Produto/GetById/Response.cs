namespace Store.Application.UseCases.Produto.GetById;

sealed record Response
    (Guid Id, DateTime? CriadoEm, DateTime? AtualizadoEm, string Descricao, decimal PrecoUnitario, int? Estoque);