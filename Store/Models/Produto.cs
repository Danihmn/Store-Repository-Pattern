namespace Store.Models;

public partial class Produto
{
    public Guid Id { get; set; }

    public DateTime? CriadoEm { get; set; }

    public DateTime? AtualizadoEm { get; set; }

    public string Descricao { get; set; } = null!;

    public decimal PrecoUnitario { get; set; }

    public int? Estoque { get; set; }
}
