namespace Store.Models;

public partial class Endereco
{
    public Guid Id { get; set; }

    public DateTime? CriadoEm { get; set; }

    public DateTime? AtualizadoEm { get; set; }

    public string Rua { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string Cep { get; set; } = null!;
}
