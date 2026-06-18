namespace Store.Domain.Abstractions;

public record Error (string Code, string Message)
{
    public static Error NotFound (string message) => new("NotFound", message);
}