namespace Store.Models;

public partial class Loja
{
    public Guid Id { get; set; }

    public DateTime? CriadoEm { get; set; }

    public DateTime? AtualizadoEm { get; set; }

    public string RazaoSocial { get; set; } = null!;

    public string? NomeFantasia { get; set; }

    public string Cnpj { get; set; } = null!;

    public bool Ativo { get; set; }

    public Guid EnderecoId { get; set; }
}
