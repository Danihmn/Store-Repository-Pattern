using FluentResults;
using Store.Domain.Abstractions;
using Store.Domain.Enums;

namespace Store.Domain.ValueObjects;

public class Status : ValueObject
{
    public EStatus Value { get; }

    private Status (EStatus value) => Value = value;

    public static Result<Status> Create (string value)
    {
        if (Enum.TryParse<EStatus>(value, true, out var status))
            return Result.Ok(new Status(status));

        return Result.Fail("Invalid status");
    }
}