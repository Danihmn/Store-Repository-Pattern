namespace Store.Models;

public partial class Pedido
{
    public Guid Id { get; set; }

    public DateTime? CriadoEm { get; set; }

    public DateTime? AtualizadoEm { get; set; }

    public Guid ClienteId { get; set; }

    public Guid EnderecoId { get; set; }

    public string? Status { get; set; }

    public decimal Total { get; set; }
}
