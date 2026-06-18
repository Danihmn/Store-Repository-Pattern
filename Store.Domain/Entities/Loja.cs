using Store.Domain.Abstractions;

namespace Store.Domain.Entities;

public class Loja : Entity
{
    public string RazaoSocial { get; set; } = null!;
    public string? NomeFantasia { get; set; }
    public string Cnpj { get; set; } = null!;
    public bool Ativo { get; set; }
    public Guid EnderecoId { get; set; }
}