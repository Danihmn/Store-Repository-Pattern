using Store.Domain.Abstractions;

namespace Store.Domain.Entities;

public class Cliente : Entity
{
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Telefone { get; set; }
}