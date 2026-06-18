using Store.Domain.Abstractions;

namespace Store.Domain.Entities;

public class Endereco : Entity
{
    public string Rua { get; set; } = null!;
    public string Cidade { get; set; } = null!;
    public string Estado { get; set; } = null!;
    public string Cep { get; set; } = null!;
}