using Store.Domain.Abstractions;

namespace Store.Domain.Entities;

public class Store : Entity
{
    public string LegalName { get; set; } = null!;
    public string? TradeName { get; set; }
    public string Cnpj { get; set; } = null!;
    public bool Active { get; set; }
    public Guid AddressId { get; set; }
}
