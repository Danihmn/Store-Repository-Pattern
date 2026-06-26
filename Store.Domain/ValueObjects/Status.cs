using Store.Domain.Abstractions;
using Store.Domain.Enums;

namespace Store.Domain.ValueObjects;

public class Status : ValueObject
{
    public EStatus Value { get; }

    public Status (string value)
    {
        if (Enum.TryParse<EStatus>(value, true, out var status))
            Value = status;
        else
            throw new InvalidOperationException("Invalid status");
    }
}