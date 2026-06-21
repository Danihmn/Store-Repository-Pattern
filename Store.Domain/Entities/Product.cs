using Store.Domain.Abstractions;

namespace Store.Domain.Entities;

public class Product : Entity
{
    public string Description { get; set; } = null!;
    public decimal UnitPrice { get; set; }
    public int? Stock { get; set; }
}
