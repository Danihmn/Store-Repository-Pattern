using Store.Domain.Abstractions;

namespace Store.Domain.Entities;

public class Pedido : Entity
{
    public string? Status { get; set; }
    public decimal Total { get; set; }
    public Guid ClienteId { get; set; }
    public Guid EnderecoId { get; set; }
}