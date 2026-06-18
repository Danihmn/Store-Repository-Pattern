using Store.Domain.Abstractions;

namespace Store.Domain.Entities;

public class Produto : Entity
{
    public string Descricao { get; set; } = null!;
    public decimal PrecoUnitario { get; set; }
    public int? Estoque { get; set; }
}