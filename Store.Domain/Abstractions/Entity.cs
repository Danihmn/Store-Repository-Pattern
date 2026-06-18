namespace Store.Domain.Abstractions;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime? CriadoEm { get; set; }
    public DateTime? AtualizadoEm { get; set; }
}