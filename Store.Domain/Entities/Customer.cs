using Store.Domain.Abstractions;

namespace Store.Domain.Entities;

public class Customer : Entity
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
}
