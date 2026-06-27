using FluentResults;

namespace Store.Domain.Abstractions;

public record Error (string Code, string Message) : IError
{
    public List<IError> Reasons { get; init; } = [];
    public Dictionary<string, object> Metadata { get; init; } = [];

    public static Error NotFound (string message) => new("NotFound", message);
}