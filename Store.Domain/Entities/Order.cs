using Store.Domain.Abstractions;

namespace Store.Domain.Entities;

public class Order : Entity
{
    public string? Status { get; set; }
    public decimal Total { get; set; }
    public Guid CustomerId { get; set; }
    public Guid AddressId { get; set; }
}
