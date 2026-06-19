namespace Store.Application.UseCases.Pedido.GetAll;

public sealed record Response
    (Guid Id, DateTime? CriadoEm, DateTime? AtualizadoEm, string? Status, decimal Total, Guid ClienteId, Guid EnderecoId);
